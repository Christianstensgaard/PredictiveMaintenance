using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL.Communication
{
    public class CommunicationLayer
    {
        /* Denne klasse har til opgave at lave en struktur for hvordan klienten og serveren pakker og ud´pakker deres data */

        /*
            
                                                        Verison 1.0
            //SL:1 = SystemLine : ID
            //HM:1 = HovedModule : ID
            //SM:1 = Sensor Module: ID
            
        String Sendt 
            *@SL:1 #HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; #HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23;# @SL:2 #HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; #HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23;#


        Split At @
            *@SL:1 #HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; #HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; 
            *@SL:2 #HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; #HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23;
            * 
            (Det giver os en opdelt SystemLinje)
            
        Split At #
            *@SL:1  //SystemLinje ID
            *#HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; 
            *#HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; 
            
            Nu har vi opdelt vores Hovedmoduler og vi kan skille vores  sensor moduler...
        Split At ;
            *#HM=1; //Hoved-Module ID
            *Sm:1 = 20,12,23;
            *Sm:2 = 20,12,23;
            *Sm:3 = 20,12,23;
           
        Split At ,
            *Sm:1,  //SensorModul ID
            *20,    //Temperatur
            *12,    //Støj
            *23;    //Vibration
         
                                                        Verison 1.1
        String Send 
            *@SL:1 #HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; #HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23;# @SL:2 #HM=1; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23; #HM=2; Sm:1 = 20,12,23;Sm:2 = 20,12,23;Sm:3 = 20,12,23;#
           
            (Jeg vil helst sende alt data via en enkelt string da det reducerer fejl) 
            
            (Eksemplet ovenfor tager brug af Split(), men det er nok ikke en effektiv måde at gøre det få, denne verision tager brug af en char array, og med noget chars som beskriver deres rolle)
            * vi ved at på indeks 0 er vores SL id: 
           
          
        Oversætning af betydende chars
            * System-Linje  = #, ## (start, Slut)
            * Hoved-Module  = $, $$ (Start, Slut)
            * Sensor-Module = @, @@ (Start, Slut)
            
        System-Linje kan have et ID eller et navn, 
        Hoved-Module kan have et ID eller et navn,
        Sensor-Module er 3 cifre, 100, 10, 1. Så når vi henter data, så vil der altid være 3 cifre. 



        String sendt by Tcp/Ip  -> 1x System-linje, 2x Hoved-moduler, 8x sensor-moduler 
            *#1##$1$$@1@@020012023@2@@020012023@3@@020012023@4@@020012023#1##$2$$@1@@020012023@2@@020012023@3@@020012023@4@@020012023

        sikkerhed: gør det næsten umuligt at læse direkte uden viden om dette.
        Fordel: Bliver meget kort, og derfor nemt at sende over Tcp
        ulempe: kræver god dokumentation, for at andre kan arbejde på dette. 


            
         */




        




    }
}
