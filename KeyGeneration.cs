using NBitcoin;

namespace Homework_15_07
{
    public class KeyGeneration
    {
        public Mnemonic mnemonic { get; private set; }
        public ExtKey hdRoot { get; private set; }
        public Key key1 { get; private set; }
        public BitcoinSecret bitcoinSecret { get; private set; }
        public string base58PrivateKey { get; private set; }
        public string publicKey { get; private set; }
        public BitcoinAddress address { get; private set; }

        public KeyGeneration()
        {
            mnemonic = new Mnemonic("drama secret allow tourist orphan manual erosion limb infant oblige fame young", Wordlist.English);
            hdRoot = mnemonic.DeriveExtKey();
            key1 = hdRoot.Derive(new KeyPath("m/84'/0'/0'/0/0")).PrivateKey;

            bitcoinSecret = key1.GetWif(Network.TestNet);
            base58PrivateKey = bitcoinSecret.ToWif();
            publicKey = key1.PubKey.ToHex();
            address = bitcoinSecret.PubKey.GetAddress(ScriptPubKeyType.Segwit, Network.TestNet);
        }
    }
}