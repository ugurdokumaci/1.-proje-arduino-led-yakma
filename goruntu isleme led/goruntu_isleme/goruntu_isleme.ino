int led1 =44;
int led2 =45;
int led3 =46;
int led4 =47;
int led5 =48;
int led6 =49;
int led7 =50;
int led8 =51;
int led9 =52;

void setup() {
  pinMode(led1,OUTPUT);
  pinMode(led2,OUTPUT);
  pinMode(led3,OUTPUT);
  pinMode(led4,OUTPUT);
  pinMode(led5,OUTPUT);
  pinMode(led6,OUTPUT);
  pinMode(led7,OUTPUT);
  pinMode(led8,OUTPUT);
  pinMode(led9,OUTPUT);
  Serial.begin(9600);

}
char blm;
void loop() {
  blm=Serial.read();
    if(blm=='1'){
      digitalWrite(led1,HIGH);
    }
    else if(blm=='2'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led1,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led1,LOW);
    }
    if(blm=='2'){
      digitalWrite(led2,HIGH);
    }
     else if(blm=='1'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led2,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led2,LOW);}
     if(blm=='3'){
      digitalWrite(led3,HIGH);
    }
     else if(blm=='2'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='1'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led3,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led3,LOW);}
     if(blm=='4'){
      digitalWrite(led4,HIGH);
    }
     else if(blm=='2'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='1'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led4,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led4,LOW);}
     if(blm=='5'){
      digitalWrite(led5,HIGH);
    }
     else if(blm=='2'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='1'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led5,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led5,LOW);}
     if(blm=='6'){
      digitalWrite(led6,HIGH);
    }
    else if(blm=='2'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='1'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led6,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led6,LOW);}
     if(blm=='7'){
      digitalWrite(led7,HIGH);
    }
    else if(blm=='2'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='1'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led7,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led7,LOW);}
     if(blm=='8'){
      digitalWrite(led8,HIGH);
    }
    else if(blm=='2'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='1'){
      digitalWrite(led8,LOW);
    }
    else if(blm=='9'){
      digitalWrite(led8,LOW);}
     if(blm=='9'){
      digitalWrite(led9,HIGH);
    }
     else if(blm=='2'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='3'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='4'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='5'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='6'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='7'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='8'){
      digitalWrite(led9,LOW);
    }
    else if(blm=='0'){
      digitalWrite(led9,LOW);}
       else if(blm=='0'){
      digitalWrite(led1,LOW);}
       else if(blm=='0'){
      digitalWrite(led2,LOW);}
       else if(blm=='0'){
      digitalWrite(led3,LOW);}
       else if(blm=='0'){
      digitalWrite(led4,LOW);}
       else if(blm=='0'){
      digitalWrite(led5,LOW);}
       else if(blm=='0'){
      digitalWrite(led6,LOW);}
       else if(blm=='0'){
      digitalWrite(led7,LOW);}
       else if(blm=='0'){
      digitalWrite(led8,LOW);}
       else if(blm=='0'){
      digitalWrite(led9,LOW);}
  

}
