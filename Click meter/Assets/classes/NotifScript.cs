using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SimpleAndroidNotifications {

	public class NotifScript : MonoBehaviour {

		public void SendNotification(TimeSpan Time) {
			NotificationManager.SendWithAppIcon(Time,
				"Clickaway",
				RandomZinnen(),
				Color.white,
				NotificationIcon.Star);
		}

		private static System.Random rand = new System.Random();

        public void cancelAll() {
            NotificationManager.CancelAll();
        }

		public String RandomZinnen(){
			String[] Zinnen = new String[] { "Het leven is als een neus, je moet eruit halen wat er in zit.",
											"Alles wat je aandacht geeft groeit.",
											"Ben je al goed op weg? Focus je aandacht even op deze app.",
											"Je bent er misschien nog niet, maar je bent wel dichter bij als gisteren.",
											"Focus op de oplossing, niet op het probleem.",
											"Een negatieve gedachten zal je nooit een posietief leven geven.",
											"Wanneer je denkt te stoppen, denk hoe je bent begonnen.",
											"Het geheim om je doel te bereiken bestaat slechts uit één woord: DOORZETTEN!",
											"Vandaag is weer een nieuwe dag, kom op! je kan het",
											"Je zal nooit je limiet weten, tenzij je ernaar doorzet",
											"Als je gelooft in jezelf is alles mogelijk",
											"MOTIVATIE, het verschil tussen gewoon en uitzonderlijk is vaak dat kleine beetje extra inzet",
											"Stop met vasthouden wat pijn doet. Reik uit naar wat jou gelukkig maakt",
											"Sta elke dag op en zeg tegen jezelf: IK KAN HET!",
											"De afstand tussen dromen en de realiteit wordt DISCIPLINE genoemd",
											"Iederen stap brengt mij dichterbij mijn doel",
											"He jij! Ja jij! Waarom wacht je nog? GA ERVOOR!",
											"Als je het kan dromen, kan je het ook bereiken!",
											"UITDAGINGEN. Zolang je jezelf af en toe tegenkomt, loop je jezelf niet voorbij",
											"Wacht niet op het perfecte moment, pak het moment en maak het perfect"};
			

			String resultaat = Zinnen[rand.Next(Zinnen.Length)];

			return resultaat;
		}
	}
}