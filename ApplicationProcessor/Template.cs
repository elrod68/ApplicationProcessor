using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ulaw.ApplicationProcessor
{
    //simplistic template engine
    class Template
    {
        private string _text;

        public Template(string templatePath)
        {
            using (var reader = new StreamReader(templatePath))
                _text = reader.ReadToEnd();
        }

        public string Render(object values)
        {
            string result = _text;
            foreach (var p in values.GetType().GetProperties())
                result = result.Replace("{" + p.Name + "}", (p.GetValue(values, null) as string) ?? string.Empty);
            return result;
        }
    }
}
