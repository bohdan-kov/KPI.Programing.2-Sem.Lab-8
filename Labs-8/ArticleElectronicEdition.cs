using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs_8_2_
{
    internal class ArticleElectronicEdition : Article
    {
        public int _countView { get; private set; }
        public bool _isPublished { get; private set; }
        public List<string> _tags { get; private set; }
        public List<string> _coments { get; private set; }
        public string _url { get; private set; }

        /// <summary>
        /// Приклад: Конструктор статті в електронному виданні
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="content">Контент</param>
        /// <param name="category">Категорія</param>
        /// <param name="autor">Автор</param>
        public ArticleElectronicEdition(string title, string content, string category, string autor, Guid id) : base(title, content, category, autor, id)
        {
            _countView = 0;
            _isPublished = true;
            _url = $"mySite/blog/article/{id}";
            _tags = new List<string>();
            _coments = new List<string>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ArticleElectronicEdition other = (ArticleElectronicEdition)obj;

            return base.Equals(obj) &&
                   _countView == other._countView &&
                   _isPublished == other._isPublished &&
                   _url == other._url &&
                   _tags.SequenceEqual(other._tags) &&
                   _coments.SequenceEqual(other._coments);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nТеги: {string.Join(", ", _tags)}\nКоментарі: {string.Join(", ", _coments)}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _countView, _isPublished, _url, _tags, _coments);
        }

        /// <summary>
        /// Приклад: використання метода, виводить статтю
        /// </summary>
        /// <returns>статтю</returns>
        /// <exception cref="ArgumentException">Перевірка чи стаття готова до публікації</exception>
        public string ViewArticle()
        {
            if (_isPublished)
            {
                _countView++;
                string tags = _tags != null && _tags.Count > 0 ? "#" + string.Join(" #", _tags) : "-";
                string formTime = _datePublication.ToString("HH:mm dd/MM/yyyy");
                string res = $"<https://{_url}>\n\n\t\t\t" +
                             $"{_title}" +
                             $"\n\n\t[Теги: {tags}]\n\t" +
                             $"[Дата: {formTime}]\t" +
                             $"[Автор: {_author}]\t\t" +
                             $"[Кiлькiсть переглядiв {_countView}]\n\n\t" +
                             $"{_content}\n\n\n";
                return res;
            }
            else
            {
                throw new ArgumentException("Стаття не опублiкована");
            }
        }

        /// <summary>
        /// Приклад: перегрузкa оператопа + (об`єднання статтів)
        /// </summary>
        /// <param name="article1">Стаття 1</param>
        /// <param name="article2">Стаття 2</param>
        /// <returns>Об'єднану статтю</returns>
        public static ArticleElectronicEdition operator +(ArticleElectronicEdition article1, ArticleElectronicEdition article2)
        {
            string headlines = $"{article1._title}, {article2._title}";
            string contents = $"{article1._content}, {article2._content}";
            string categories = $"{article1._category}, {article2._category}";
            string autors = $"{article1._author}, {article2._author}";
            List<string> tags = new List<string>();
            tags.AddRange(article1._tags);
            tags.AddRange(article2._tags);

            Guid newId = Guid.NewGuid();
            var article = new ArticleElectronicEdition(headlines, contents, categories, autors, newId);

            if (tags.Count > 0)
            {
                foreach (var tag in tags)
                {
                    article.addTag(tag);
                }
            }

            return article;
        }

        /// <summary>
        /// Приклад метода додавання тегів до статті
        /// </summary>
        /// <param name="tag"></param>
        /// <exception cref="ArgumentNullException">Перевірка на коректність введення тегу</exception>
        public void addTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException("Тег не може бути пустим");
            }
            else
            {
                _tags.Add(tag);
            }
        }

        /// <summary>
        /// Приклад метода додавання коментаря до статті
        /// </summary>
        /// <param name="tags"></param>
        /// <exception cref="ArgumentNullException">Перевірка на коректність введення комент.</exception>
        public void addComment(string tags)
        {
            if (string.IsNullOrEmpty(tags))
            {
                throw new ArgumentNullException("Коментар не може бути пустим");
            }
            else
            {
                _coments.Add(tags);
            }
        }

        /// <summary>
        /// Приклад метода архівування статті
        /// </summary>
        public void ToArchive()
        {
            _isPublished = false;
            Console.WriteLine($"Статтю: \"{_title}\" архiвована!");
        }

        /// <summary>
        /// Приклад метода розархірування статті
        /// </summary>
        public string Unzip()
        {
            _isPublished = true;
            return $"Статтю: \"{_title}\" опублiковано!";
        }
    }
}
