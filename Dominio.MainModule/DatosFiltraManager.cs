using Dominio.Entidades;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.MainModule
{
    public class DatosFiltraManager
    {
        public List<Vendedor> ListarVendedor(string empresa)
        {
            return new DatosFiltradoDAL().ListarVendedor(empresa);
        }

        public List<Familia> ListarFamilia(string empresa)
        {
            return new DatosFiltradoDAL().ListarFamilia(empresa);
        }

        public List<Almacen> ListarAlmacen(string empresa)
        {
            return new DatosFiltradoDAL().ListarAlmacen(empresa);
        }

        public List<SubFamilia> ListarSubFamilia(string empresa, string codFam)
        {
            return new DatosFiltradoDAL().ListarSubFamilia(empresa,codFam);
        }

        public List<Grupo> ListarGrupo(string empresa, string codSub)
        {
            return new DatosFiltradoDAL().ListarGrupo(empresa, codSub);
        }

        public List<ComboGeneral> ListarComboGeneral(string empresa, string strFiltroCombo, string strSegundoFiltro)
        {
            return new DatosFiltradoDAL().ListarComboGeneral(empresa, strFiltroCombo,strSegundoFiltro);
        }
    }
}
