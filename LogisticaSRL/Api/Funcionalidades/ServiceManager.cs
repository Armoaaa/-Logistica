using Api.Funcionalidades.Centrales;
using Api.Funcionalidades.Envios;
using Api.Funcionalidades.HistorialesEnvio;
using Api.Funcionalidades.IntentosEntrega;
using Api.Persistencia;

namespace Api
{
    public class ServiceManager
    {
        private readonly Lazy<CentralService> _centralService;
        private readonly Lazy<EnviosService> _enviosService;
        private readonly Lazy<HistorialEnvioService> _historialEnvioService;
        private readonly Lazy<IntentoEntregaService> _intentoEntregaService;

        public ServiceManager(GestionPedidoDbContext context)
        {
            _centralService = new Lazy<CentralService>(() => new CentralService(context));
            _enviosService = new Lazy<EnviosService>(() => new EnviosService(context));
            _historialEnvioService = new Lazy<HistorialEnvioService>(() => new HistorialEnvioService(context));
            _intentoEntregaService = new Lazy<IntentoEntregaService>(() => new IntentoEntregaService(context));
        }

        public CentralService CentralService => _centralService.Value;
        public EnviosService EnviosService => _enviosService.Value;
        public HistorialEnvioService HistorialEnvioService => _historialEnvioService.Value;
        public IntentoEntregaService IntentoEntregaService => _intentoEntregaService.Value;
    }
}