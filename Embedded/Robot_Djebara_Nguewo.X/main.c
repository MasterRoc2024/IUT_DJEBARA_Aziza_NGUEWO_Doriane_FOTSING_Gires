#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include "ChipConfig.h"
#include "IO.h"
#include "timer.h"
#include "PWM.h"
#include "UART.h"

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
    
    PWMSetSpeedConsigne(20, MOTEUR_GAUCHE);
    PWMSetSpeedConsigne(-20, MOTEUR_DROIT);    

    LED_BLANCHE = 1;
    LED_BLEUE = 1;
    LED_ORANGE = 1;

    /****************************************************************************************************/
    // Boucle Principale
    /****************************************************************************************************/
    while (1) {
        //SendMessageDirect((unsigned char*) "Bonjour", 7);
        //__delay32(4000000);

    } // fin main
}


