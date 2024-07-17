using Newtonsoft.Json.Linq;
using RestSharp;


namespace Homework_15_07
{
    public class Functions
    {
        public async Task GetBalance()
        {
            var generatedKey = new KeyGeneration();
            var client = new RestClient($"https://api.blockcypher.com/v1/btc/test3/addrs/{generatedKey.address}/balance");
            var request = new RestRequest { Method = Method.Get };

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var balance = JObject.Parse(response.Content);

                Console.WriteLine($"Баланс: {balance["balance"]} сатоши");
                Console.WriteLine($"Не потрачено: {balance["unspent_balance"]} сатоши");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Не удалось получить баланс адреса.");
                Console.WriteLine();
            }
        }

        public async Task GetAllTransactions()
        {
            var generatedKey = new KeyGeneration();
            var client = new RestClient($"https://api.blockcypher.com/v1/btc/test3/addrs/{generatedKey.address}?unspentOnly=true");
            var request = new RestRequest { Method = Method.Get };

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var data = JObject.Parse(response.Content);
                var utxos = (JArray)data["txrefs"];

                if (utxos != null)
                {
                    foreach (var utxo in utxos)
                    {
                        Console.WriteLine($"Транзакция: {utxo["tx_hash"]}");
                        Console.WriteLine($"Выход: {utxo["tx_output_n"]}");
                        Console.WriteLine($"Сумма: {utxo["value"]} сатоши");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось получить UTXO для адреса.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Не удалось получить данные для адреса.");
                Console.WriteLine();
            }
        }
    }
}