// See https://aka.ms/new-console-template for more information

/*DateTime date = DateTime.Now; // selected date in the UI
string yearMonth = date.ToString("yyyy-MM");

string jevNo = "JEV-"+yearMonth+"-"+"00001";
string[] parts = jevNo.Split('-');

int sequence = int.Parse(parts[3]);
sequence++;

int sequence2 = int.Parse(parts[1]);
string format = string.Join("-",parts);
//parts[3] = sequence.ToString("D5");
//string format = string.Join("-",parts);


Console.WriteLine(format);*/
DateTime selectedDate = new DateTime(2026, 8, 5);

DateTime statusDate = selectedDate.Date.Add(DateTime.Now.TimeOfDay);

Console.WriteLine(statusDate);
