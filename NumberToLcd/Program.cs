using NumbersToLcd;

Console.WriteLine("Please provide the number:");
var text = Console.ReadLine();

try
{
    var lcd = new LcdDisplay(text, 1, 2);
    Console.Write(lcd.ToString());

    lcd = new LcdDisplay(text, 5, 6);
    Console.Write(lcd.ToString());

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


Console.ReadLine();