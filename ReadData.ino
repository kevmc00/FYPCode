// These constants won't change. They're used to give names to the pins used:
const int analogInPin1 = A0;  // Analog input pin that the potentiometer is attached to
const int analogInPin2 = A1; 
int16_t sensorValue1 = 0;        // value read from the EMG
int16_t sensorValue2 = 0;
String stringVal1 = "";
String stringVal2 = "";
const uint16_t t1_load = 0;
const uint16_t t1_comp = 1991;
const int memCap = 1024;
bool tx = false;
char cmd = 's';
const int forwards = 2;
const int backwards = 3;//assign relay INx pin to arduino pin
int count = 0;
const int power = 8;
const int readSwitch = 10;
const int gnd = 12;
int val = 0;

void setup() {
  // initialize serial communications at 9600 bps:
  Serial.begin(230400);
  pinMode(forwards, OUTPUT);//set relay as an output
  pinMode(backwards, OUTPUT);//set relay as an output
  pinMode(power, OUTPUT);
  pinMode(readSwitch, INPUT);
  pinMode(gnd, OUTPUT);
  digitalWrite(power, HIGH);
  digitalWrite(gnd, LOW);

  TCCR1A = 0;     //Reset timer 1 CtrlReg A

  // Prescaler of 8
  TCCR1B &= ~(1 << CS12); // CS12 = 0
  TCCR1B |= (1 << CS11);  // CS11 = 1
  TCCR1B &= ~(1 << CS10); // CS10 = 0

  TCNT1 = t1_load;
  OCR1A = t1_comp;
  TIMSK1 = (1 << OCIE1A);
  //cli();
  sei();    //Enable Interrupts

}

void loop() {
  
  // FUNCTIONALITY:
  // 1) Read from sensor
  // 2) Send via bluetooth
  // 3) Check for command
  // 4) Execute command if needs be

  // COMMANDS
  // u = up (timed)
  // d = down (timed)
  // s = stay
  // f = up
  // b = down 
  val = digitalRead(readSwitch);
  if(Serial.available()){
    cmd = (char) Serial.read();
    //Serial.print("Initial Command set to ");
    //Serial.println(cmd);
    //delay(100);
    
    if(cmd == 's'){
      digitalWrite(forwards, LOW);
      digitalWrite(backwards, LOW);
    }
    else if(cmd == 'd'){
      digitalWrite(forwards, LOW);
      digitalWrite(backwards, HIGH);
    }
    else if(cmd == 'u'){                // Actuator "Up" command received
      digitalWrite(forwards, HIGH);     // Switch relays in order to move actuator up
      digitalWrite(backwards, LOW);     // "
      do {                              
        val = digitalRead(readSwitch);  // read switch pin
        delay(1);
      } while (val == 0);               // breaks out when switch is tripped
      digitalWrite(forwards, LOW);      // Switch relays in order to stop actuator
      digitalWrite(backwards, LOW);     // "
    }
    else if(cmd == 'f'){
      digitalWrite(forwards, HIGH);
      digitalWrite(backwards, LOW);
    }else if(cmd == 'b'){
      digitalWrite(forwards, LOW);
      digitalWrite(backwards, HIGH);
    }
    else{
      //Serial.println("Not catching");
    }
  }


}

ISR(TIMER1_COMPA_vect){
  TCNT1 = t1_load;
  
  sensorValue1 = analogRead(analogInPin1);
  sensorValue2 = analogRead(analogInPin2);
  
  Serial.print(sensorValue1 - 316);
  Serial.print(",");
  Serial.println(sensorValue2 - 316);
  
}
