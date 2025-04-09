using HIPS.HSPS.Interface.Persistence.Web;
using HSPS.Web.Common;
using HSPS.Web.IServices.BASE;
using HSPS.Web.Model.Models.Extensions;
using HSPS.Web.Repository;
using Serilog;

namespace HSPS.Web.Services.BASE
{
    public class CommonServices : ICommonServices
    {
        /// <summary>
        /// 根据ID获取实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityByID<T>(int id) where T : Model.Models.Extensions.IEntity
        {
            Func<T> func = () =>
            {
                Type type = typeof(T);

                dynamic entity = null;
                HIPS.HSPS.Interface.Persistence.Web.IEntity interfaceEntity = null;

                if (type == typeof(ReportParseRule))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.ParseRule();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.Configure))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.Configure();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.Department))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.Department();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.PrinterPosition))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.PrinterPosition();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.Printer))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.UserTerminal();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.ReportType))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.ReportType();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.SignatureLocation))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.SignatureLocation();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.Station))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.Station();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.StationTerminalRelation))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.StationTerminalRelation();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                else if (type == typeof(Model.Models.Extensions.UserDoctor))
                {
                    interfaceEntity = new HIPS.HSPS.Interface.Persistence.Web.UserDoctor();
                    entity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                }
                return entity;
            };
            return Invoke(func);
        }


        /// <summary>
        /// 根据ID获取实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityByID<T>(long id) where T : Model.Models.Extensions.IEntity
        {
            Func<T> func = () =>
            {
                Type type = typeof(T);
                dynamic entity = null;
                HIPS.HSPS.Interface.Persistence.Web.IEntity interfaceEntity = null;
                if (type == typeof(Model.Models.Extensions.Report))
                {
                    interfaceEntity = new ReportContext();
                }
                interfaceEntity = RemotingInterfaceService.EntityService.Load(id, interfaceEntity);
                entity = interfaceEntity;
                return entity;
            };
            return Invoke(func);
        }

        private T Invoke<T>(Func<T> invoke)
        {
            try
            {
                return invoke();
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("根据ID获取{0}实体失败", typeof(T)), ex);
                throw;
            }
        }
    }
}
