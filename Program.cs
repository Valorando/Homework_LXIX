using Homework_15_07;

var key = new KeyGeneration();
var function = new Functions();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Выберите нужную вам опцию, затем нажмите на соответствующую клавишу:");
    Console.WriteLine("1 - Информация о кошельке");
    Console.WriteLine("2 - Баланс кошелька");
    Console.WriteLine("3 - История транзакций");
    Console.WriteLine("4 - Выйти");
    Console.WriteLine();

    ConsoleKeyInfo option = Console.ReadKey();
    Console.WriteLine();

    switch (option.KeyChar)
    {
        case '1':
            Console.WriteLine($"Mnemo фраза: {key.mnemonic}");
            Console.WriteLine($"Приватный ключ: {key.base58PrivateKey}");
            Console.WriteLine($"Публичный ключ: {key.publicKey}");
            Console.WriteLine($"Адрес кошелька: {key.address}");
            Console.WriteLine();
            break;

        case '2':
            Console.WriteLine("Выполняется запрос данных с ресурса, пожалуйста подождите...");
            Console.WriteLine();
            await function.GetBalance();
            Console.WriteLine();
            break;

        case '3':
            Console.WriteLine("Выполняется запрос данных с ресурса, пожалуйста подождите...");
            Console.WriteLine();
            await function.GetAllTransactions();
            Console.WriteLine();
            break;

        case '4':
            return;

        default:
            Console.WriteLine("Нажатая вами клавиша отсутствует в списке опций.");
            Console.WriteLine();
            break;
    }
}