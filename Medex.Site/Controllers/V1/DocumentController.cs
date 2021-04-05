using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/documents")]
    public class DocumentController : BaseController
    {
        readonly IDocumentService _documentService;
        public DocumentController(IDocumentService productService)
        {
            _documentService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DocumentDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<DocumentDto>>> Create([FromForm] IFormFile file) =>
           Ok(await _documentService.CreateAsync(new DocumentNewDto
           {
               Data = file,
               Name = file.FileName,
               Extension = file.FileName.Replace(file.Name, ""),
           }));


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        public async Task<FileResult> Get(long id)
        {
            var doc = await _documentService.GetDtoByIdAsync(id);

            if (doc == null)
                throw new NullReferenceException($"Не найден документ с Id={id}");

            return File(doc.Data, $"application/{doc.Extension}", doc.Name);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _documentService.DeleteByIdAsync(id));

    }
}
