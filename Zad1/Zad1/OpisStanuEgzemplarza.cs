﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class OpisStanuEgzemplarza
    {

        protected DateTime dataZakupu;
        protected Boolean stan; // dostepny istnieje
        protected string opisStanu; // w jakim jest stanie co zniszczone
        protected Egzemplarz ktoryEgzemplarz;

        public DateTime DataZakupu { get; set; }
        public Boolean Stan { get; set; }
        public Egzemplarz KtoryEgzemplarz { get; set; }
        public string OpisStanu { get; set; }

        public override string ToString()
        {
            string s = ktoryEgzemplarz + " Data zakupu " + dataZakupu + "Stan:" + opisStanu + "\n";
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj is OpisStanuEgzemplarza)
            {
                OpisStanuEgzemplarza tmp = (OpisStanuEgzemplarza)obj;
                return dataZakupu.Equals(tmp.dataZakupu) && ktoryEgzemplarz.Equals(tmp.ktoryEgzemplarz) && stan.Equals(tmp.stan);
            }
            else
            {
                return true;
            }
        }
    }
}
