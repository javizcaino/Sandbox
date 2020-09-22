namespace ODataSamples.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;

    using ODataSamples.Business.Interfaces;
    using ODataSamples.DomainModels;

    public class ProductsController : ODataController
    {
        private readonly IProductsBusinessService _businessService;

        public ProductsController(IProductsBusinessService businessService)
        {
            _businessService = businessService;
        }

        [EnableQuery]
        public async Task<IQueryable<Product>> Get()
        {
            return await _businessService.RetrieveAllAsync().ConfigureAwait(false);
        }

        [EnableQuery]
        public async Task<ActionResult<Product>> Get([FromODataUri] int key)
        {
            Product product = await _businessService.RetrieveAsync(key).ConfigureAwait(false);

            return product == null ? NotFound() : (ActionResult<Product>)product;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _businessService.CreateAsync(product).ConfigureAwait(false);

            return Created(product);
        }

        [HttpDelete]
        public async Task<ActionResult<Product>> Delete([FromODataUri] int key)
        {
            try
            {
                await _businessService.DeleteAsync(key).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException)
                {
                    return NotFound();
                }

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] Product product)
        {
            if (key != product.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _businessService.UpdateAsync(product).ConfigureAwait(false);

                return Updated(product);
            }
            catch (DbUpdateConcurrencyException) when (!ProductExists(key))
            {
                return NotFound();
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromODataUri] int key, Delta<Product> delta)
        {
            if (!TryValidateModel(delta.GetInstance()))
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product item = _businessService.Retrieve(key);

                delta.Patch(item);

                // Force update of last change date whatever they send us in the request.
                item.LastUpdatedOn = DateTime.UtcNow;

                _businessService.Update(item);
                return Updated(item);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("Rate")]
        public IActionResult RateProduct([FromODataUri] int key, ODataActionParameters parameters)
        {
            try
            {
                int rating = -1;
                string userName = User.Identity.Name ?? string.Empty;
                string comments = null;

                if (parameters == null)
                {
                    return BadRequest();
                }

                if (!parameters.ContainsKey("rating"))
                {
                    return BadRequest();
                }

                rating = (int)parameters["rating"];

                if (parameters.ContainsKey("comments"))
                {
                    comments = (string)parameters["comments"];
                }

                _businessService.RateProduct(key, rating, userName, comments);
                return Ok();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex, new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                    DateParseHandling = DateParseHandling.DateTimeOffset,
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                }));
            }
        }

        [HttpPost]
        [ActionName("RateProduct")]
        public IActionResult RateProductUsingEntity(
            [FromODataUri] int key,
            ODataActionParameters parameters)
        {
            try
            {
                if (parameters == null)
                {
                    return BadRequest();
                }

                if (!parameters.ContainsKey("value"))
                {
                    return BadRequest();
                }

                ProductRating rating = (ProductRating)parameters["value"];

                rating.ProductId = key;
                rating.Username = User.Identity.Name ?? string.Empty;
                rating.RatedOn = DateTime.UtcNow;

                _businessService.RateProduct(rating);

                return Ok();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult MeanProductRating([FromODataUri] int key)
        {
            try
            {
                return Ok(_businessService.GetMeanProductRating(key));
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ProductExists(int id)
        {
            return _businessService.RetrieveAll().Any(_ => _.Id.Equals(id));
        }
    }
}