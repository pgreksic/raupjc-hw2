Odgovori na pitanja iz petog zadatka:
*************************************

#Pitanje 1:
  Izvršavanje programa trajalo je 5,0029344 sekundi. 

------------------> Synchronous long operation calls finished 5,0029344 sec.


#Pitanje 2:
  Sve operacije su se izvodile na istoj dretvi.


#Pitanje 3:
  Izvršavanje programa trajalo je 1,0392582 sekundi.

---------------> Synchronous long operation calls finished 1,0392582 sec.

#Pitanje 4:
  Svaka operacija se izvela na zasebnoj dretvi(otvorili smo 5 novih dretvi).

#Pitanje 5:
  Do neželjenog ponašanja kod istovremenog pristupa može doći kad jedna dretva dohvati trenutnu vrijednost iz memorije i 
krene izvršavati neku operaciju, a u međuvremenu podatku pristupi druga dretva i pročita "stari" podatak jer prva dretva nije uspjela na vrijeme spremiti novu vrijednost. 
U tom slučaju će biti vidljiva operacija samo one dretve koja zadnja spremi podatak.   
