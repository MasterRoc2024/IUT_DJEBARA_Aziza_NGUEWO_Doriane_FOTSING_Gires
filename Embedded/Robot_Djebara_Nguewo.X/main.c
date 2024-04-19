#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include "ChipConfig.h"
#include "IO.h"
#include "timer.h"
#include "PWM.h"
#include "UART.h"
#include "CB_TX1.h"
#include "CB_RX1.h"
#include <libpic30.h>

int main(void) {
    /***************************************************************************************************/
    //Initialisation de l?oscillateur
    /****************************************************************************************************/
    InitOscillator();

    /****************************************************************************************************/
    // Configuration des entrées sorties
    /****************************************************************************************************/
    InitIO();
    InitTimer1();
    InitTimer23();
    InitUART();
    
    InitPWM();
    
    //PWMSetSpeedConsigne(20, MOTEUR_GAUCHE);
    //PWMSetSpeedConsigne(-20, MOTEUR_DROIT);    

    LED_BLANCHE = 1;
    LED_BLEUE = 1;
    LED_ORANGE = 1;

    /****************************************************************************************************/
    // Boucle Principale
    /****************************************************************************************************/
    while (1) {
        int i;
for(i=0; i< CB_RX1_GetDataSize(); i++)
{
unsigned char c = CB_RX1_Get();
SendMessage(&c,1);
}
__delay32(1000);

        //SendMessageDirect((unsigned char*) "Bonjour", 7);
        //__delay32(4000000);
        //SendMessage((unsigned char*) "Bonjour", 7);

    } // fin main
}


