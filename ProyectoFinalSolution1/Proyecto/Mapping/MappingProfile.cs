using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Citas, Models.Citas>().ReverseMap();
            CreateMap<data.Contacto, Models.Contacto>().ReverseMap();
            CreateMap<data.Dentista, Models.Dentista>().ReverseMap();
            CreateMap<data.DetalleFactura, Models.DetalleFactura>().ReverseMap();
            CreateMap<data.Eventos, Models.Eventos>().ReverseMap();
            CreateMap<data.ExpedientePaciente, Models.ExpedientePaciente>().ReverseMap();
            CreateMap<data.FacturaPaciente, Models.FacturaPaciente>().ReverseMap();
            CreateMap<data.Ingresos, Models.Ingresos>().ReverseMap();
            CreateMap<data.Inventario, Models.Inventario>().ReverseMap();
            CreateMap<data.PacienteNuevo, Models.PacienteNuevo>().ReverseMap();
            CreateMap<data.Producto, Models.Producto>().ReverseMap();
            CreateMap<data.Recepcionista, Models.Recepcionista>().ReverseMap();
            CreateMap<data.Reunion, Models.Reunion>().ReverseMap();
            CreateMap<data.Review, Models.Review>().ReverseMap();
            CreateMap<data.Tratamiento, Models.Tratamiento>().ReverseMap();
        }
    }
}
