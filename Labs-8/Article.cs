using System;

namespace Labs_8_2_
{
    public abstract class Article
    {
        public Guid _id { get; }
        public string _title { get; private set; }
        public string _content { get; private set; }

        public int _maxLenght { get; private set; }
        public string _category { get; private set; }
        public string _author { get; private set; }
        public DateTimeOffset _datePublication { get; private set; }

        public Article(string title, string content, string category, string author, Guid id, int maxLenght = 1000)
        {
            //Валідація заголовка
            ValidateTitle(title);

            //Валідація контента
            ValidateContent(content);

            if (maxLenght < 0 && maxLenght > 1000)
            {
                throw new ArgumentException("Введіть коректне значення максимальної довжини для контента");
            }

            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentNullException("Категория не може бути пуста");
            }
            _id = id;
            _title = title;
            _content = content;
            _maxLenght = maxLenght;
            _category = category;
            _author = author;
            _datePublication = DateTimeOffset.Now;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }

            Article other = (Article)obj;

            return _id == other._id && _title == other._title && _content == other._content && _maxLenght == other._maxLenght && _category == other._category && _author == other._author && _datePublication == other._datePublication;
        }


        public override string ToString()
        {
            return $"Назва: {_title}\n {_content}";
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(_id, _title, _content, _maxLenght, _category, _author, _datePublication);
        }



        /// <summary>
        /// Приклад перегрузки метода AddContent
        /// </summary>
        /// <param name="text"></param>
        public void AddContent(string text)
        {
            ValidateContent(text);
            _content += $"{text} \n\t";
        }

        public void AddContent(string imagesPath, string caption)
        {
            ValidateTitle(caption);
            _content += $"Images: {imagesPath} - {caption}";
        }

        public void ChangeTitle(string title)
        {
            ValidateTitle(_title);
            _title = title;
        }


        /// <summary>
        /// Перевiрка на валiдацiю для заголовка 
        /// </summary>
        /// <param name="title"></param>
        /// <exception cref="ArgumentNullException">Заголовок не може бути пустим</exception>
        /// <exception cref="ArgumentException">
        /// Заголовок не може мiстити бiльше 100 симолiв
        /// Загаловок не може починатися iз малої лiтери або ж починат. з пробiли
        /// Загаловок не може мiстити недоступний символи
        /// </exception>
        private void ValidateTitle(string title)
        {

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("Заголовок не може бути пустою");
            }

            if (title.Length > 100)
            {
                throw new ArgumentException("Заголовок не може мiстити бiльше 100 симолiв");
            }

            if (char.IsLower(title[0]) || title.Trim() != title)
            {
                throw new ArgumentException("Загаловок не може починатися iз малої лiтери або ж починат. з пробiли");
            }

            string[] invalidCharactes = { "@", "#", "$", "%" };

            foreach (string c in invalidCharactes)
            {
                if (title.Contains(c))
                {
                    throw new ArgumentException($"Загаловок не може мiстити недоступний символ {c}");
                }
            }


        }

        /// <summary>
        /// Перевiрка на валiдацiю для контента
        /// </summary>
        /// <param name="content"></param>
        /// <exception cref="ArgumentNullException">Контент не може бути пустим</exception>
        /// <exception cref="ArgumentException">
        /// Контент не може мiстити бiльше {_maxLenght} симолiв
        /// Контент не може починатися iз малої лiтери або ж починат. з пробiли
        /// Контент не може мiстити недоступні символи
        /// Контент не повинен мiстить забороненних слiв
        /// </exception>
        private void ValidateContent(string content)
        {

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("Контент не може бути пустим");
            }

            if (content.Length < _maxLenght)
            {
                throw new ArgumentException($"Контент не може мiстити бiльше {_maxLenght} симолiв");
            }

            if (char.IsLower(content[0]) || content.Trim() != content)
            {
                throw new ArgumentException("Контент не може починатися iз малої лiтери або ж починат. з пробiли");
            }

            string[] invalidCharactes = { "<", ">" };

            foreach (string c in invalidCharactes)
            {
                if (content.Contains(c))
                {
                    throw new ArgumentException($"Контент не може мiстити недоступний символ {c}");
                }
            }

            //Перевiрка на вмiст заборонених слiв (матюкiв)
            string[] invalidBadWorlds = { "badword1", "badword2" };
            foreach (var word in invalidBadWorlds)
            {
                if (content.ToLower().Contains(word))
                {
                    throw new ArgumentException($"Контент не повинен мiстить забороненних слiв");
                }
            }
        }
    }
}
