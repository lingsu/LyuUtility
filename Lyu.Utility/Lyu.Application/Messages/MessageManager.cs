using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Caching;
using Lyu.Application.Domain.Message;

namespace Lyu.Application.Messages
{
    public class MessageManager: IDomainService
    {
        public IQueryable<MessageTemplate> MeaasgeTemplates { get { return _messageRepository.GetAll(); } }
        public ICacheManager CacheManager { get; set; }
        protected IRepository<MessageTemplate> _messageRepository;

        public MessageManager(IRepository<MessageTemplate> messageRepository)
        {
            _messageRepository = messageRepository;
        }


        public virtual Task<MessageTemplate> FindByNameAsync(string name)
        {
            return _messageRepository.FirstOrDefaultAsync(s => s.Name == name);
        }
        public virtual async Task<MessageTemplate> GetActiveMessageTemplate(string name)
        {
            var messageTemplate = await _messageRepository.FirstOrDefaultAsync(s => s.Name == name);

            //no template found
            if (messageTemplate == null)
                return null;

            //ensure it's active
            var isActive = messageTemplate.IsActive;
            if (!isActive)
                return null;

            return messageTemplate;
        }
    }
}