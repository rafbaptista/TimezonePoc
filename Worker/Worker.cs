using Worker.Net6.Extensions;

namespace Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var utcNow = DateTimeOffset.UtcNow;
                //var utcNow = DateTimeOffset.UtcNow.AddHours(-3);

                var convertedDate = utcNow.ConvertToBraziliaTimeZone();

                _logger.LogInformation("Horário universal (UTC) : {utcNow}", utcNow.ToString("dd/MM/yyyy HH:mm:ss \"UTC\"zzz"));
                _logger.LogInformation("Horário convertido para fuso de Brasília: {convertedDate}", convertedDate.ToString("dd/MM/yyyy HH:mm:ss \"UTC\"zzz"));

                var delay = GetDelay(convertedDate);

                _logger.LogInformation("Worker irá ficar em espera por {delay}", delay);

                await Task.Delay(delay, stoppingToken);
                DoWork();
            }
        }

        public TimeSpan GetDelay(DateTimeOffset date)
        {
            TimeSpan timeOfDay = date.TimeOfDay;
            TimeSpan limitTime = new TimeSpan(17, 0, 0);

            if (limitTime >= timeOfDay)
                return limitTime - timeOfDay;

            return TimeSpan.FromHours(24) - timeOfDay - limitTime;
        }

        public void DoWork()
        {
            _logger.LogInformation("Realizando algum processamento");
        }
    }
}