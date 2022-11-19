//svjetsko prvenstvo


using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
System.Random random = new System.Random();

var choice = "";
var team = new Dictionary<string, (string position, int rating)>()
{
    {"Dominik Livakovic", ("GK", 80) },
    {"Ivo Grbic", ("GK", 74) },

    {"Martin Erlic", ("DF", 74) },
    {"Duje Caleta-Car", ("DF", 78) },
    {"Dejan Lovren", ("DF", 78) },
    {"Domagoj Vida", ("DF", 76) },  
    {"Josip Sutalo", ("DF", 75) },
    {"Josko Gvardiol", ("DF", 81) },

    {"Luka Modric", ("MF", 88) },  
    {"Marcelo Brozovic", ("MF", 86) },
    {"Mateo Kovacic", ("MF", 84) },
    {"Ivan Rakitic", ("MF", 82) },
    {"Mario Pasalic", ("MF", 81) },
    {"Lovro Majer", ("MF", 80) },

    {"Marko Livaja", ("FW", 77) },
    {"Ante Budimir", ("FW", 76) },
    {"Ante Rebic", ("FW", 80) },
    {"Nikola Kalinic", ("FW", 74) },
    {"Petar Musa", ("FW", 74)},
    {"Antonio Colak", ("FW", 73) }

};
var listOfCountries = new List<string>() { "Hrvatska", "Belgija", "Kanada", "Maroko"};
var numOfMatches = 0;
var goalScorers = new Dictionary<string, int>() { };



var countryDictionary = new Dictionary<string, (int points, int goalDif)>()
{
    {"Hrvatska", (0,0) },
    {"Belgija", (0,0) },
    {"Kanada", (0,0) },
    {"Maroko", (0,0) }

};





var scores = new List<string>() { };


while (choice != "0")
{
    
    Console.WriteLine("Nalazite se u izborniku aplikacije za Svjetsko prvenstvo! Vaši izbori su:");
    Console.WriteLine("1 - Odradi trening");
    Console.WriteLine("2 - Odigraj utakmicu");
    Console.WriteLine("3 - Statistika");
    Console.WriteLine("4 - Kontrola igraca");
    Console.WriteLine("0 - Izlaz iz aplikacije");
    Console.WriteLine("Unesite svoj izbor (samo broj): ");
    choice = Console.ReadLine();
    
    Console.WriteLine($"Vaš izbor je {choice}");

    switch (choice)
    {
        case "1":
            {
                Console.Clear();
                Console.WriteLine("Izabrali ste opciju 1 - Odradi trening");
                OdradiTrening(team);
                break;
            }
        case "2":
            {
                Console.Clear();
                Console.WriteLine("Izabrali ste opciju 2 - Odigraj utakmicu");
                if (numOfMatches < 6)
                {
                    OdigrajUtakmicu(team, listOfCountries, countryDictionary, goalScorers, scores);
                }
                else
                    Console.WriteLine("Već je odigran maksimalan broj utakmica pa ova opcija više nije dostupna.");
                
                break;
            }
        case "3":
            {
                Console.Clear();
                Console.WriteLine("Izabrali ste opciju 3 - Statistika.");

                Console.WriteLine("1 - Ispis igraca onako kako su spremljeni");
                Console.WriteLine("2 - Ispis igraca po ratingu uzlazno");
                Console.WriteLine("3 - Ispis igraca po ratingu silazno");
                Console.WriteLine("4 - Ispis igraca po imenu i prezimenu (Vi unesete ime i prezime, a ispise se pozicija i rating tog igraca)");
                Console.WriteLine("5 - Ispis igraca po ratingu (Ispisu se svi igraci s tim ratingom)");
                Console.WriteLine("6 - Ispis igraca po poziciji (Ispisu se svi igraci na unesenoj poziciji)");
                Console.WriteLine("7 - Ispis trenutnih prvih 11");
                Console.WriteLine("8 - Ispis strijelaca i koliko golova imaju");
                Console.WriteLine("9 - Ispis svih rezultata ekipe");
                Console.WriteLine("10 - Ispis rezultata svih ekipa");
                Console.WriteLine("11 - Ispis tablice grupe");
                Console.WriteLine("");
                Console.WriteLine("Izaberite koji podatak vas zanima (samo broj).");
                var choiceStat = Console.ReadLine();

                switch (choiceStat)
                {
                    case "1":
                        {
                            Statistika1(team);
                            break;
                        }
                    case "2":
                        {
                            Statistika2(team);
                            break;
                        }
                    case "3":
                        {
                            Statistika3(team); 
                            break;
                        }
                    case "4":
                        {
                            Statistika4(team);
                            break;
                        }
                    case "5":
                        {
                            Statistika5(team);
                            break;
                        }
                    case "6":
                        {
                            Statistika6(team);
                            break;
                        }
                    case "7":
                        {
                            Statistika7(team);
                            break;
                        }
                    case "8":
                        {
                            Statistika8(goalScorers);
                            break;
                        }
                    case "9":
                        {
                            Statistika9(scores, listOfCountries);
                            break;
                        }
                    case "10":
                        {
                            Statistika10(scores);
                            break;
                        }
                    case "11":
                        {
                            Statistika11(countryDictionary);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Niste izabrali valjanu opciju za statistiku");
                            break;
                        }
                        
                        
                }



                break;
            }
        case "4":
            {
                Console.Clear();
                Console.WriteLine("Izabrali ste opciju 4 - Kontrola igraca");

                Console.WriteLine("1 - Unos novog igraca");
                Console.WriteLine("2 - Brisanje igraca");
                Console.WriteLine("3 - Uredivanje igraca"); //ovo ce se kasnije granat na 3 opcije

                Console.WriteLine("Izaberite opciju unosom broja.");
                var choicePlayerControl = Console.ReadLine();

                switch (choicePlayerControl)
                {
                    case "1":
                        {
                            InsertNewPlayer(team);
                            break;
                        }
                    case "2":
                        {
                            DeletePlayer(team);
                            break;
                        }
                    case "3":
                        {
                            EditPlayer(team);
                            break;
                        }

                    default:
                        break;
                }
                break;
            }
        case "0":
            {
                Console.Clear();
                Console.WriteLine("Izabrali ste opciju 0 - Izlaz iz aplikacije");
                break;
            }
        default:
            {
                Console.Clear();
                Console.WriteLine("Niste izabrali valjanu opciju. Pokušajte opet");
                break;
            }
            
    }
}

void OdradiTrening(Dictionary<string, (string position, int rating)> myDictionary) //triba dodat kontrolu da rating ne ide ispod 1 i priko 100 odnosno ako bi prišlo samo stavit na 1 ili na 100
{
    
    int numRandom = 0;   
    var nameOfPlayer = "";
    var positionOfPlayer = "";
    var ratingOfPlayer = 0;
    foreach (var item in myDictionary)
    {
        var positionRatingPair = ("", 0);
        numRandom = random.Next(-5, 5);
        positionOfPlayer = item.Value.Item1;
        ratingOfPlayer = item.Value.Item2;
        nameOfPlayer = item.Key;

        if (ratingOfPlayer + numRandom > 100)
        {
            positionRatingPair = (positionOfPlayer, 100);
        }
        else if (ratingOfPlayer + numRandom < 1)
        {
            positionRatingPair = (positionOfPlayer, 1);
        }
        else
        {
            positionRatingPair = (positionOfPlayer, ratingOfPlayer + numRandom);
        }


        myDictionary[nameOfPlayer] = positionRatingPair;

        Console.WriteLine($"Rating igrača {nameOfPlayer} prije treninga je bio {ratingOfPlayer}, a sada je {ratingOfPlayer + numRandom}");

    }
    
}

void OdigrajUtakmicu(Dictionary<string, (string position, int rating)> myDictionary, List<string> countries, Dictionary<string, (int points, int goalDiff)> myDictionary2, Dictionary<string, int> myDictionary3, List<string> scoresList) //dodat da se ne može priko 6 utakmica
{
    int croatiaGoals = 0;
    int otherTeamGoals = 0;
    //iducih 70 linija samo stavlja 11 najboljih u listu 

    var chosenPlayers = new List<string>();
    var gk = new Dictionary<string, (string position, int rating)>() { };
    var df = new Dictionary<string, (string position, int rating)>() { };
    var mf = new Dictionary<string, (string position, int rating)>() { };
    var fw = new Dictionary<string, (string position, int rating)>() { };
    
    var listGk = new List<string>();
    var listDf = new List<string>();
    var listMf = new List<string>();
    var listFw = new List<string>();



    foreach (var item in myDictionary)  //ova cila petlja napravi listu sa 11 najboljih po pozicijama
    {
        if (item.Value.position == "GK")
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            gk.Add(item.Key, positionRatingPair);
        }
        else if (item.Value.position == "DF") 
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            df.Add(item.Key, positionRatingPair);
        }
        else if (item.Value.position == "MF") 
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            mf.Add(item.Key, positionRatingPair);
        }
        else
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            fw.Add(item.Key, positionRatingPair);
        }
    }
    var sortedGk = from entry in gk orderby entry.Value.rating descending select entry;
    var sortedDf = from entry in df orderby entry.Value.rating descending select entry;
    var sortedMf = from entry in mf orderby entry.Value.rating descending select entry;
    var sortedFw = from entry in fw orderby entry.Value.rating descending select entry;

    foreach ( var item in sortedGk ) 
    {
        listGk.Add(item.Key.ToString() );
    }

    foreach (var item in sortedDf)
    {
        listDf.Add(item.Key.ToString());
    }

    foreach (var item in sortedMf)
    {
        listMf.Add(item.Key.ToString());
    }

    foreach (var item in sortedFw)
    {
        listFw.Add(item.Key.ToString());
    }

    if (sortedGk.Count() > 0 && sortedDf.Count() > 3 && sortedMf.Count() > 2 && sortedFw.Count() > 2)
    {
        chosenPlayers.AddRange(listGk.Take(1));
        chosenPlayers.AddRange(listDf.Take(4));
        chosenPlayers.AddRange(listMf.Take(3));
        chosenPlayers.AddRange(listFw.Take(3));

        Console.WriteLine("Prva postava za utakmicu je: ");
        foreach (var item in chosenPlayers)
        {
            Console.WriteLine(item);
        }
        //ovde
        var firstMatchup = new List<string>();
        var secondMatchup = new List<string>();
        var firstMatchupScore = new List<int>();
        var secondMatchupScore = new List<int>();

        var count = 0;
        var exit = "";
        while (count < 2 && exit != "0") //unos država koje će igrat
        {
            Console.WriteLine("");
            Console.WriteLine("Unesite reprezentaciju prve utakmice (reprezentacije u skupini su: Hrvatska, Belgija, Kanada i Maroko)");
            Console.WriteLine("Unesite 0 za izlaz iz ove funkcije i povratak u pocetni izbornik");
            var country = Console.ReadLine();
            if (countries.Contains(country) && !firstMatchup.Contains(country))  // && !firstMatchup.Contains(country) da ne može sama protiv sebe igrat
            {
                count++;
                firstMatchup.Add(country);

            }
            else if (country == "0")
            {
                Console.WriteLine("Vracamo vas na pocetni izbornik");
                exit = "0";

            }
            else
                Console.WriteLine("Niste unijeli ispravnu reprezentaciju ili ste unijeli istu 2 puta");


        }
        if (exit != "0")   //Ovo odigraje utakmicu nakon sta se odabralo ko ce igrat s kin
        {
            numOfMatches++;


            Console.Clear();              //ovaj dio samo ispiše koje će reprezentacije igrat
            Console.WriteLine("");
            Console.WriteLine("Prvu utakmicu ce igrati reprezentacije: ");

            foreach (var item in firstMatchup)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("");
            Console.WriteLine("Drugu utakmicu ce igrati reprezentacije: ");

            foreach (var item in countries)
            {
                if (item != firstMatchup[0] && item != firstMatchup[1])
                {
                    secondMatchup.Add(item);
                    Console.WriteLine(item);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                firstMatchupScore.Add(random.Next(0, 5));
                secondMatchupScore.Add(random.Next(0, 5));
            }
            Console.WriteLine("");
            Console.WriteLine($"Utakmica između {firstMatchup[0]} i {firstMatchup[1]} završila je rezultatom {firstMatchupScore[0]} : {firstMatchupScore[1]}.");
            Console.WriteLine($"Utakmica između {secondMatchup[0]} i {secondMatchup[1]} završila je rezultatom {secondMatchupScore[0]} : {secondMatchupScore[1]}.");

            //sad želiš u ovi myDictionary2 -> countryDictionary minjat points i goal diff ovisno o rezultatu



            if (firstMatchupScore[0] > firstMatchupScore[1])  //ovo troje minja prvu utakmicu
            {
                var pointsGoalDiffPair1 = (myDictionary2[firstMatchup[0]].points + 3, myDictionary2[firstMatchup[0]].goalDiff + (firstMatchupScore[0] - firstMatchupScore[1]));
                var pointsGoalDiffPair2 = (myDictionary2[firstMatchup[1]].points, myDictionary2[firstMatchup[1]].goalDiff + (firstMatchupScore[1] - firstMatchupScore[0]));
                myDictionary2[firstMatchup[0]] = pointsGoalDiffPair1;
                myDictionary2[firstMatchup[1]] = pointsGoalDiffPair2;


            }
            else if (firstMatchupScore[0] < firstMatchupScore[1])
            {
                var pointsGoalDiffPair1 = (myDictionary2[firstMatchup[0]].points, myDictionary2[firstMatchup[0]].goalDiff + (firstMatchupScore[0] - firstMatchupScore[1]));
                var pointsGoalDiffPair2 = (myDictionary2[firstMatchup[1]].points + 3, myDictionary2[firstMatchup[1]].goalDiff + (firstMatchupScore[1] - firstMatchupScore[0]));
                myDictionary2[firstMatchup[0]] = pointsGoalDiffPair1;
                myDictionary2[firstMatchup[1]] = pointsGoalDiffPair2;
            }
            else
            {
                var pointsGoalDiffPair1 = (myDictionary2[firstMatchup[0]].points + 1, myDictionary2[firstMatchup[0]].goalDiff);
                var pointsGoalDiffPair2 = (myDictionary2[firstMatchup[1]].points + 1, myDictionary2[firstMatchup[1]].goalDiff);
                myDictionary2[firstMatchup[0]] = pointsGoalDiffPair1;
                myDictionary2[firstMatchup[1]] = pointsGoalDiffPair2;
            }




            if (secondMatchupScore[0] > secondMatchupScore[1])  //ovo troje minja drugu utakmicu
            {
                var pointsGoalDiffPair1 = (myDictionary2[secondMatchup[0]].points + 3, myDictionary2[secondMatchup[0]].goalDiff + (secondMatchupScore[0] - secondMatchupScore[1]));
                var pointsGoalDiffPair2 = (myDictionary2[secondMatchup[1]].points, myDictionary2[secondMatchup[1]].goalDiff + (secondMatchupScore[1] - secondMatchupScore[0]));
                myDictionary2[secondMatchup[0]] = pointsGoalDiffPair1;
                myDictionary2[secondMatchup[1]] = pointsGoalDiffPair2;


            }
            else if (secondMatchupScore[0] < secondMatchupScore[1])
            {
                var pointsGoalDiffPair1 = (myDictionary2[secondMatchup[0]].points, myDictionary2[secondMatchup[0]].goalDiff + (secondMatchupScore[0] - secondMatchupScore[1]));
                var pointsGoalDiffPair2 = (myDictionary2[secondMatchup[1]].points + 3, myDictionary2[secondMatchup[1]].goalDiff + (secondMatchupScore[1] - secondMatchupScore[0]));
                myDictionary2[secondMatchup[0]] = pointsGoalDiffPair1;
                myDictionary2[secondMatchup[1]] = pointsGoalDiffPair2;
            }
            else
            {
                var pointsGoalDiffPair1 = (myDictionary2[secondMatchup[0]].points + 1, myDictionary2[secondMatchup[0]].goalDiff);
                var pointsGoalDiffPair2 = (myDictionary2[secondMatchup[1]].points + 1, myDictionary2[secondMatchup[1]].goalDiff);
                myDictionary2[secondMatchup[0]] = pointsGoalDiffPair1;
                myDictionary2[secondMatchup[1]] = pointsGoalDiffPair2;
            }

            foreach (var item in myDictionary2)
            {
                Console.WriteLine(item);
            }

            //int croatiaGoals = 0;
            //int otherTeamGoals = 0;

            if (firstMatchup.Contains("Hrvatska"))   //sa ovin utvrđivan koliko su golova zabile hrv i druga ekipa 
            {

                int indexHr = firstMatchup.FindIndex(a => a.Contains("Hrvatska"));
                for (int i = 0; i < 2; i++)
                {
                    if (i != indexHr)
                    {
                        otherTeamGoals = firstMatchupScore[i];
                    }
                }
                croatiaGoals = firstMatchupScore[indexHr];

            }
            else if (secondMatchup.Contains("Hrvatska"))
            {
                int indexHr = secondMatchup.FindIndex(a => a.Contains("Hrvatska"));
                for (int i = 0; i < 2; i++)
                {
                    if (i != indexHr)
                    {
                        otherTeamGoals = secondMatchupScore[i];
                    }
                }
                croatiaGoals = secondMatchupScore[indexHr];
            }

            var nRandomInts = new List<int>() { };
            var alreadyOccuredScorer = new List<int>();

            if (croatiaGoals > otherTeamGoals)  //hrv pobjedila - strijelcima 5 i svima 2, dodat random strijelce
            {
                foreach (var item in myDictionary)  //ovo svakome poveća za 2
                {
                    var positionOfPlayer = item.Value.Item1;
                    var ratingOfPlayer = item.Value.Item2;
                    var nameOfPlayer = item.Key;
                    var positionRatingPair = ("", 0);
                    if (ratingOfPlayer > 98)
                    {
                        positionRatingPair = (positionOfPlayer, 100);
                    }
                    else
                    {
                        positionRatingPair = (positionOfPlayer, ratingOfPlayer + 2);
                    }
                   
                    myDictionary[nameOfPlayer] = positionRatingPair;
                }
                //ovdi je prije stalo ono da se svakom strijelcu doda 5 al si maka doli to izvan ovih ifova tkd mu se doda bez obzira je li pobjedia ili nije
            }


            else if (otherTeamGoals > croatiaGoals) //hrv izgubila strijelcima 5 i svima -2, dodat random strijelce
            {
                foreach (var item in myDictionary)  //ovo svakome smanji za 2
                {
                    var positionOfPlayer = item.Value.Item1;
                    var ratingOfPlayer = item.Value.Item2;
                    var nameOfPlayer = item.Key;

                    var positionRatingPair = ("", 0);
                    if (ratingOfPlayer < 3)
                    {
                        positionRatingPair = (positionOfPlayer, 1);
                    }
                    else
                    {
                        positionRatingPair = (positionOfPlayer, ratingOfPlayer - 2);
                    }

                    myDictionary[nameOfPlayer] = positionRatingPair;

                }
            }


            for (int i = 0; i < croatiaGoals; i++)  //ovo napravi listu random integera od onolko brojeva kolko je golova dala hrv
            {
                nRandomInts.Add(random.Next(0, 11));
            }

            foreach (var item in nRandomInts)  //ovaj dio strijelcima doda 5%
            {
                if (!alreadyOccuredScorer.Contains(item))
                {
                    var positionOfPlayer = myDictionary[chosenPlayers[item]].position;
                    var ratingOfPlayer = myDictionary[chosenPlayers[item]].rating;
                    var nameOfPlayer = chosenPlayers[item];

                    var positionRatingPair = ("", 0);
                    if (ratingOfPlayer > 95)
                    {
                        positionRatingPair = (positionOfPlayer, 100);
                    }
                    else
                    {
                        positionRatingPair = (positionOfPlayer, ratingOfPlayer + 5);
                    }

                    myDictionary[chosenPlayers[item]] = positionRatingPair;
                }

                if (myDictionary3.ContainsKey(chosenPlayers[item])) //ovo ako je igrač već u listi strijelaca
                {
                    myDictionary3[chosenPlayers[item]] += 1;


                }
                else  //ovo ako nije još
                {
                    myDictionary3.Add(chosenPlayers[item], 1);
                }

                alreadyOccuredScorer.Add(item);
            }

            Console.WriteLine("");
            Console.WriteLine("Stanje poslije ove utakmice je: ");
            foreach (var item in myDictionary)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");
            Console.WriteLine("Lista strijelaca Hrvatske reprezentacije sada izgleda ovako: ");
            foreach (var item in myDictionary3)
            {
                Console.WriteLine(item);
            }
            scoresList.Add($"{firstMatchup[0]} {firstMatchupScore[0]} : {firstMatchupScore[1]} {firstMatchup[1]}");
            scoresList.Add($"{secondMatchup[0]} {secondMatchupScore[0]} : {secondMatchupScore[1]} {secondMatchup[1]}");
        }

    }
    else
        Console.WriteLine("Nema dovoljno igrača na nekoj poziciji pa se utakmica ne može odigrati.");

}

void Statistika1(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste izbor 1 - Ispis igraca onako kako su spremljeni");
    Console.WriteLine("");
    foreach (var item in teamDic)
    {
        Console.WriteLine(item);
    }
}

void Statistika2(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste izbor 2 - Ispis igraca po ratingu uzlazno");
    var sorted = from entry in teamDic orderby entry.Value.rating ascending select entry;
    foreach (var item in sorted)
    {
        Console.WriteLine(item);
    }
}

void Statistika3(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste izbor 3 - Ispis igraca po ratingu silazno");
    var sorted = from entry in teamDic orderby entry.Value.rating descending select entry;
    foreach (var item in sorted)
    {
        Console.WriteLine(item);
    }
}
void Statistika4(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste izbor 4 - Ispis igraca po imenu i prezimenu (Vi unesete ime i prezime, a ispise se pozicija i rating tog igraca)");
    Console.WriteLine("Odaberite igraca");
    var playerName = Console.ReadLine();
    if (teamDic.ContainsKey(playerName))
    {
        Console.WriteLine($"{playerName}: {teamDic[playerName].position}, {teamDic[playerName].rating}");
    }
    else
        Console.WriteLine("Taj igrač tenutno nije u reprezentaciji.");

    
}

void Statistika5(Dictionary<string, (string position, int rating)> teamDic) //vrati se na ovo
{
    Console.WriteLine("Izabrali ste izbor 5 - Ispis igraca po ratingu (Ispisu se svi igraci s tim ratingom)");

    //parsiranje

    Console.WriteLine("Unesite rating koji zelite provjeriti");
    int result = 0;
    var rating = int.TryParse(Console.ReadLine(), out result);
    int counterOfPlayers = 0;
    if (result > 0)
    {
        foreach (var item in teamDic)
        {
            if (result == item.Value.rating)
            {
                Console.WriteLine(item.Key);
                counterOfPlayers++;
            }
        }
        if (counterOfPlayers == 0)
        {
            Console.WriteLine($"Ni jedan igrac nema rating {result}");
        }
    }
    else
        Console.WriteLine("Krivo ste unijeli rating");
    


}

void Statistika6(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste izbor 6 - Ispis igraca po poziciji (Ispisu se svi igraci na unesenoj poziciji)");
    Console.WriteLine("Unesite zeljenu pozicijiu (moguce opcije su GK, DF, MF, FW");
    var playerPosition = Console.ReadLine();
    Console.WriteLine("");

    if (playerPosition == "GK" || playerPosition == "DF" || playerPosition == "MF" || playerPosition == "FW")
    {
        Console.WriteLine($"Igraci na poziciji {playerPosition} su:");
        foreach (var item in teamDic)
        {
            if (item.Value.position == playerPosition)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
    else
        Console.WriteLine("To nije jedna od mogucih poziciija");
} 

void Statistika7(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste izbor 7 - Ispis trenutnih prvih 11");

    var chosenPlayers = new List<string>();
    var gk = new Dictionary<string, (string position, int rating)>() { };
    var df = new Dictionary<string, (string position, int rating)>() { };
    var mf = new Dictionary<string, (string position, int rating)>() { };
    var fw = new Dictionary<string, (string position, int rating)>() { };

    var listGk = new List<string>();
    var listDf = new List<string>();
    var listMf = new List<string>();
    var listFw = new List<string>();

    foreach (var item in teamDic)  //ova cila petlja napravi listu sa 11 najboljih po pozicijama
    {
        if (item.Value.position == "GK")
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            gk.Add(item.Key, positionRatingPair);
        }
        else if (item.Value.position == "DF")
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            df.Add(item.Key, positionRatingPair);
        }
        else if (item.Value.position == "MF")
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            mf.Add(item.Key, positionRatingPair);
        }
        else
        {
            var positionRatingPair = (item.Value.position, item.Value.rating);
            fw.Add(item.Key, positionRatingPair);
        }
    }
    var sortedGk = from entry in gk orderby entry.Value.rating descending select entry;
    var sortedDf = from entry in df orderby entry.Value.rating descending select entry;
    var sortedMf = from entry in mf orderby entry.Value.rating descending select entry;
    var sortedFw = from entry in fw orderby entry.Value.rating descending select entry;

    foreach (var item in sortedGk)
    {
        listGk.Add(item.Key.ToString());
    }

    foreach (var item in sortedDf)
    {
        listDf.Add(item.Key.ToString());
    }

    foreach (var item in sortedMf)
    {
        listMf.Add(item.Key.ToString());
    }

    foreach (var item in sortedFw)
    {
        listFw.Add(item.Key.ToString());
    }

    if (sortedGk.Count() > 0 && sortedDf.Count() > 3 && sortedMf.Count() > 2 && sortedFw.Count() > 2)
    {
        chosenPlayers.AddRange(listGk.Take(1));
        chosenPlayers.AddRange(listDf.Take(4));
        chosenPlayers.AddRange(listMf.Take(3));
        chosenPlayers.AddRange(listFw.Take(3));

        Console.WriteLine("Prva postava za utakmicu je: ");
        foreach (var item in chosenPlayers)
        {
            Console.WriteLine(item);
        }
    }
}

void Statistika8(Dictionary<string, int> goalScorersDic)
{
    Console.WriteLine("Izabrali ste izbor 8 - Ispis strijelaca i koliko golova imaju");
    Console.WriteLine("Lista strijelaca: ");
    foreach (var item in goalScorersDic)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

void Statistika9(List<string> scoresList, List<string> countriesList)
{
    Console.WriteLine("Izabrali ste izbor 9 - Ispis svih rezultata ekipe");
    Console.WriteLine("Unesite reprezentaciju cije rezultate zelite vidjeti (opcije su: Hrvatska, Belgija, Kanada, Maroko");
    var countryName = Console.ReadLine();
    if (countriesList.Contains(countryName))
    {
        foreach (var item in scoresList)
        {
            if (item.Contains(countryName))
            {
                Console.WriteLine(item);
            }
        }
    }
    else
        Console.WriteLine("To nije jedna od drzava u nasoj skupini");
}

void Statistika10(List<string> scoresList)
{
    Console.WriteLine("Izabrali ste izbor 10 - Ispis rezultata svih ekipa");
    foreach (var item in scoresList)
        Console.WriteLine(item);
}

void Statistika11(Dictionary<string, (int points, int goalDif)> countryDic)
{
    Console.WriteLine("Izabrali ste izbor 11 - Ispis tablice grupe");
    //var sortedCountryDic = from entry in countryDic orderby entry.Value.points ascending select entry;
    var sortedCountryDic = countryDic.OrderByDescending(x => x.Value.points).ThenByDescending(x => x.Value.goalDif).ToDictionary(x => x.Key, x => x.Value);
    foreach (var item in sortedCountryDic) { Console.WriteLine(item); }
}

void InsertNewPlayer(Dictionary<string, (string position, int rating)> teamDic)
{
    var listOfPositions = new List<string>() { "GK", "DF", "MF", "FW"};
    Console.WriteLine("Izabrali ste opciju 1 - Unos novog igraca");

    if (teamDic.Count < 26)
    {
        Console.WriteLine("Unesite ime novog igraca (za povratak na glavni izbornik nemojte unijeti nista)");
        var nameOfNewPlayer = Console.ReadLine();
        if (!teamDic.ContainsKey(nameOfNewPlayer) && nameOfNewPlayer != "")
        {
            Console.WriteLine("Unesite poziciju (opcije su: GK, DF, MF, FW)");
            var positionOfNewPlayer = Console.ReadLine();
            if (listOfPositions.Contains(positionOfNewPlayer))
            {
                Console.WriteLine("Unesite rating igraca od 1 do 100");
                int ratingOfNewPlayer = 0;
                var tryRatingOfNewPlayer = int.TryParse(Console.ReadLine(), out ratingOfNewPlayer);
                if (ratingOfNewPlayer > 0 && ratingOfNewPlayer < 101)
                {
                    Console.WriteLine($"Uspješno ste unijeli igraca {nameOfNewPlayer}, {positionOfNewPlayer}, {ratingOfNewPlayer}");
                    var newPlayerPositionRatingPair = (positionOfNewPlayer, ratingOfNewPlayer);
                    teamDic.Add(nameOfNewPlayer, newPlayerPositionRatingPair);

                }
                else
                    Console.WriteLine("Neispravan unos ratinga");
            }
            else
                Console.WriteLine("To nije valjana pozicija (???Vraceni ste na pocetni izbornik???)");
        }
        else
            Console.WriteLine("Izlaz. (Ime ne smije biti prazno i igrac s tim imenom ne smije vec biti u ekipi)");
    }

}

void DeletePlayer(Dictionary<string, (string position, int rating)> teamDic)
{
    Console.WriteLine("Izabrali ste opciju 2 - Brisanje igraca");
    Console.WriteLine("Unesite ime i prezime igraca kojeg zelite obrisati");
    var nameOfPlayerToDelete = Console.ReadLine();
    if (teamDic.ContainsKey(nameOfPlayerToDelete))
    {
        teamDic.Remove(nameOfPlayerToDelete);
        Console.WriteLine($"Uspjesno ste obrisali igraca {nameOfPlayerToDelete}");
    }
    else
        Console.WriteLine("Taj igrac uopce nije u reprezentaciji");
}

void EditPlayer(Dictionary<string, (string position, int rating)> teamDic)
{
    var positionList = new List<string>() {"GK", "DF", "MF", "FW"};
    Console.WriteLine("Izabrali ste opciju 3 - Uredivanje igraca");
    Console.WriteLine("1 - Uredi ime i prezime igraca");
    Console.WriteLine("2 - Uredi poziciju igraca (opcije su GK, DF, MF, FW)");
    Console.WriteLine("3 - Uredi rating igraca");
    Console.WriteLine("Unesite zeljenu opciju");
    var choiceOfEdit = Console.ReadLine();

    switch (choiceOfEdit)
    {
        case "1":
            {
                Console.WriteLine("Izabrali ste opciju 1 - Uredi ime i prezime igraca");
                Console.WriteLine("Unesite sadasnje ime i prezime zeljenog igraca");
                var currentName = Console.ReadLine();   
                if (teamDic.ContainsKey(currentName))
                {
                    var playerRating = teamDic[currentName].rating;
                    var playerPosition = teamDic[currentName].position;
                    var positionRatingPair = (playerPosition, playerRating);
                    Console.WriteLine("Unesite novo ime i prezime koje zelite dati tome igracu");
                    var newName = Console.ReadLine();
                    if (newName != "")
                    {
                        teamDic.Remove(currentName);
                        teamDic.Add(newName, positionRatingPair);
                        Console.WriteLine($"Uspjesno ste promijenili ime igraca iz {currentName} u {newName}");
                    }
                    else
                        Console.WriteLine("Neispravan unos (unijeli ste prazno ime");

                    
                }
                else
                    Console.WriteLine("Taj igrac nije u reprezentaciji. Vraceni ste na glavni izbornik.");
                break;
            }
        case "2":
            {
                Console.WriteLine("Izabrali ste opciju 2 - Uredi poziciju igraca ");
                Console.WriteLine("Unesite ime i prezime igraca kojem zelite izmjeniti poziciju");
                var playerToChangePosition = Console.ReadLine();
                if (teamDic.ContainsKey(playerToChangePosition))
                {
                    var currentPosition = teamDic[playerToChangePosition].position;
                    Console.WriteLine($"Trenutna pozicija tog igraca je {teamDic[playerToChangePosition].position}");
                    Console.WriteLine("Unesite poziciju na koju ga zelite staviti (opcije su GK, DF, MF, FW)");
                    var newPosition = Console.ReadLine();
                    if (positionList.Contains(newPosition))
                    {
                        var playerRating = teamDic[playerToChangePosition].rating;
                        var positonRatingPair = (newPosition, playerRating);
                        teamDic[playerToChangePosition] = positonRatingPair;
                        Console.WriteLine($"Uspjesno ste promijenili poziciju igraca {playerToChangePosition} iz {currentPosition} u {newPosition}");
                    }
                    else
                        Console.WriteLine("To nije jedna od mogucih pozicija");
                }
                else
                    Console.WriteLine("Taj igrac nije u reprezentaciji pa ne mozemo mijenjati poziciju. Vraceni ste na glavni izbornik");
                break;
            }
        case "3":
            {
                Console.WriteLine("Izabrali ste opciju 3 - Uredi rating igraca");
                Console.WriteLine("Unesite ime i prezime igraca kojemu zelite urediti rating");
                var playerToChangeRating = Console.ReadLine();
                if (teamDic.ContainsKey(playerToChangeRating))
                {
                    var currentRating = teamDic[playerToChangeRating].rating;
                    Console.WriteLine($"Trenutni rating igraca {playerToChangeRating} je {currentRating}");
                    Console.WriteLine("Unesite novi rating koji mu zelite pridjeliti (od 1 do 100)");
                    var newRating = 0;
                    var tryNewRating = int.TryParse(Console.ReadLine(), out newRating);
                    if (newRating > 0 && newRating < 101)
                    {
                        var playerPosition = teamDic[playerToChangeRating].position;
                        var positionRatingPair = (playerPosition, newRating);
                        teamDic[playerToChangeRating] = positionRatingPair;
                        Console.WriteLine($"Uspjesno ste promijenili rating igraca {playerToChangeRating} iz {currentRating} u {newRating}");
                    }
                    else
                        Console.WriteLine("Neispravan unos ratinga");

                }
                else
                    Console.WriteLine("Taj igrac nije u reprezentaciji pa mu ne mozemo promijeniti rating. Vraceni ste na glavni izbornik.");
                break;
            }

        default:
            Console.WriteLine("Krivi unos opcije. Vraceni ste na glavni izbornik");
            break;
    }
}
