namespace Mimisbrunnr.Data
{
    public class DataInit
    {
        private readonly Context _context;

        public DataInit(Context context)
        {
            _context = context;
        }

        public async Task Init()
        {
            await _context.Database.EnsureDeletedAsync();
            if(await _context.Database.EnsureCreatedAsync())
            {

            }
        }
    }
}
