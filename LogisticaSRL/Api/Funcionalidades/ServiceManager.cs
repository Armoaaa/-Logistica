using Api.Funcionalidades.Centrales;
using Api.Funcionalidades.Domicilios;
using Api.Funcionalidades.Envios;
using Api.Funcionalidades.HistorialesEnvio;
using Api.Funcionalidades.IntentosEntrega;
using Api.Funcionalidades.Personas;
using Api.Funcionalidades.Sucursales;
using Api.Persistencia;

namespace Api
{
    public class ServiceManager
    {
        private readonly Lazy<CentralService> _centralService;
        private readonly Lazy<DomicilioService> _domicilioService;
        private readonly Lazy<EnviosService> _enviosService;
        private readonly Lazy<HistorialEnvioService> _historialEnvioService;
        private readonly Lazy<IntentoEntregaService> _intentoEntregaService;
        private readonly Lazy<PersonaService> _personaService;
        private readonly Lazy<SucursalService> _sucursalService;

        public ServiceManager(GestionPedidoDbContext context)
        {
            _centralService = new Lazy<CentralService>(() => new CentralService(context));
            _domicilioService = new Lazy<DomicilioService>(() => new DomicilioService(context));
            _enviosService = new Lazy<EnviosService>(() => new EnviosService(context));
            _historialEnvioService = new Lazy<HistorialEnvioService>(() => new HistorialEnvioService(context));
            _intentoEntregaService = new Lazy<IntentoEntregaService>(() => new IntentoEntregaService(context));
            _personaService = new Lazy<PersonaService>(() => new PersonaService(context));
            _sucursalService = new Lazy<SucursalService>(() => new SucursalService(context));
        }

        public CentralService CentralService => _centralService.Value;
        public DomicilioService DomicilioService => _domicilioService.Value;
        public EnviosService EnviosService => _enviosService.Value;
        public HistorialEnvioService HistorialEnvioService => _historialEnvioService.Value;
        public IntentoEntregaService IntentoEntregaService => _intentoEntregaService.Value;
        public PersonaService PersonaService => _personaService.Value;
        public SucursalService SucursalService => _sucursalService.Value;
    }
}