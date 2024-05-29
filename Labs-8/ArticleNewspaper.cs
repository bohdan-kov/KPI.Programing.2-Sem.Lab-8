using Labs_8_2_;
using System;


namespace Labs_8_2_
{
    internal class ArticleNewspaper : Article
    {
        public string _pressa { get; private set; }
        public double _subscription { get; private set; }
        public ArticleNewspaper(string title, string content, string category, string autor, string pressa, Guid id, double subscription = 1) : base(title, content, category, autor, id)
        {
            if (string.IsNullOrEmpty(pressa))
            {
                throw new ArgumentNullException("Назва редакцiї не може бути пустою");
            }

            _pressa = pressa;
            _subscription = subscription;
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ArticleNewspaper other = (ArticleNewspaper)obj;

            return base.Equals(obj) && _pressa == other._pressa && _subscription == other._subscription;
        }
        public override string ToString()
        {
            return base.ToString() + $"Видавництво:{_pressa}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _pressa, _subscription);
        }

        /// <summary>
        /// Приклад метода, пререгляд газети
        /// </summary>
        /// <returns>повертає газету</returns>
        public string ReadArticle()
        {
            string formTime = _datePublication.ToString("HH:mm dd/MM/yyyy");
            string res = $"\t\t\t/{_title}/\n\n" +
                $"|[Дата: {formTime}]\t" +
                $"[Назва преси {_pressa}]\t" +
                $"[Категорiя: {_category}]\t" +
                $"[Автор: {_author}]|\n\n" +
                $"\t{_content}\n\n\n";
            return res;
        }


        /// <summary>
        /// Приклад метода, змiна вартостi передплати
        /// </summary>
        /// <param name="costMonth">Вартiсть мiсяця</param>
        public void ChangeSubscription(double costMonth)
        {
            if (costMonth <= 0)
            {
                throw new ArgumentException("Вартiсть передплати не може бути вiд'ємною або ж нулем");
            }
            _subscription = costMonth;
        }

        /// <summary>
        /// Приклад перегрузки петода, змiна передплати де iншим параметром
        /// є додання перiода на передану вартiсть.
        /// </summary>
        /// <param name="costPeriod">Вартiсть на вказаний перiод</param>
        /// <param name="Period">Перiод</param>
        public void ChangeSubscription(double costPeriod, int Period)
        {
            if (costPeriod <= 0)
            {
                throw new ArgumentException("Вартiсть передплати не може бути вiд'ємною або ж нулем");
            }
            if (Period <= 0)
            {
                throw new ArgumentException("Перiод не може бути вiд'ємним");
            }
            _subscription = costPeriod / Period;
        }

        public double SeeCost()
        {
            return _subscription;
        }
    }
}
