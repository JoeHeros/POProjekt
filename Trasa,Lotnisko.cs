﻿using System;
using System.Collections.Generic;
namespace LiniaLotnicza
{
	public class Trasa
	{
		private double Dystans;
		private List<Lotnisko> Lotniska;
		private int Czas;
		public Trasa() { }

		// Zwykly konstruktor
		public Trasa(double dystans, int czas)
		{
			if (czas <= 0)
				throw new CzasException();
			if (dystans <= 0)
				throw new DystansException();
			this.Dystans = dystans;
			this.Czas = czas;
			Lotniska = new List<Lotnisko>();
		}

		public double getDystans() { return this.Dystans; }
		public List<Lotnisko> getLotniska() { return this.Lotniska; }
		public int getCzas() { return this.Czas; }
		public void dodajLotnisko(Lotnisko L) { Lotniska.Add(L); }
		public void usunLotnisko(Lotnisko L)
		{
			//Metoda przeglada cala liste lotnisk i porownuje pola obiektow poprzez metode porownajLotnisko, a nastepnie usuwa poszczegolne lotniska.
			for (int i = 0; i < this.Lotniska.Count; i++)
			{
				if (L.Equals(this.Lotniska[i]))
					Lotniska.RemoveAt(i);
			}
		}

		// Metoda Equals porownuje poszczegolne pola i wywoluje prywatna metode porownajLotniska ktora porownuje listy lotnisk i zwraca true jezeli listy sa takie same.
		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Trasa t = (Trasa)obj;
				List<Lotnisko> l = t.getLotniska();     // Sprawdzenie czy listy
				if (l.Count != this.Lotniska.Count)     // posiadaja taka sama
					return false;                       // liczbe elementow.

				if (this.Dystans == t.getDystans() && this.Czas == t.getCzas() && porownajLotniska(t))
					return true;
				else
					return false;
			}
		}
		private bool porownajLotniska(Trasa t)
		{
			List<Lotnisko> l = t.getLotniska();
			bool zmienna = false;
			for (int i = 0; i < l.Count; i++)
			{
				if (l[i].Equals(this.Lotniska[i]))
					zmienna = true;
				else
					return false;
			}
			return zmienna;
		}
	}
	public class Lotnisko
	{
		private string Kraj, Miasto, Id;
		public Lotnisko() { }
		public Lotnisko(string kraj, string miasto, string id) { this.Kraj = kraj; this.Miasto = miasto; this.Id = id; }
		public string getKraj() { return this.Kraj; }
		public string getMiasto() { return this.Miasto; }
		public string getId() { return this.Id; }
		public bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Lotnisko l = (Lotnisko)obj;
				return (this.Id == l.getId() && this.Kraj == l.getKraj() && this.Miasto == l.getMiasto());
			}
		}
	}
		public class TrasaException : Exception { }
		public class DystansException : TrasaException { }
		public class CzasException : TrasaException { }
	
}