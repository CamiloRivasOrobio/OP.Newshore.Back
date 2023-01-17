using Ardalis.Specification;
using OP.Newshore.Domain.Entities;

namespace OP.Newshore.Application.Specifications
{
    public class PagedFlightSpecification : Specification<Flight>
    {
        public PagedFlightSpecification(int pageSize, int pageNumber, int? nmid, string? cddocumento, string? dsnombres, string? dsapellidos, DateTime? fenacimiento,
            string? cdtipo, string? cdgenero, string? cdusuario, string? dsdireccion, string? cdtelefonoFijo, string? cdtelefonoMovil, string? dsemail, DateTime? feregistro, DateTime? febaja)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
