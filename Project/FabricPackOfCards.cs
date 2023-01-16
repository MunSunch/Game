using System;
using System.Collections;

namespace Project
{
    public class FabricPackOfCards
    {
        public static ArrayList create(TypePack type)
        {
            switch (type)
            {
                case TypePack.STANDART:
                {
                    ArrayList pack = new ArrayList(36);
                    var typesKarta = Enum.GetValues(typeof(TypeCard));
                    var suits = Enum.GetValues(typeof(Suit));
                    foreach (var typeKarta in typesKarta)
                    {
                        foreach (var suit in suits)
                        {
                            pack.Add(new Card((TypeCard) typeKarta, (Suit) suit));
                        }
                    }

                    return pack;
                }
                default:
                    return null;
            }
        }
    }                                                                                 
                                                                                      
    public enum TypePack                                                              
    {                                                                                 
        STANDART                                                                      
    }                                                                                 
}                                                                                     