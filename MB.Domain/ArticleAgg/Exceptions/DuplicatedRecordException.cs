using System;

namespace MB.Domain.ArticleAgg.Exceptions
{
    public class DuplicatedRecordException:Exception
    {
        public DuplicatedRecordException()
        {
        }
        public DuplicatedRecordException(string message) : base(message)
        {
        }
    }
}
