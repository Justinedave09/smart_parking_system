#include <Servo.h>

const int trigPin = 2;
const int echoPin = 3;
const int servoPin = 4; // Moved to Pin 4 to avoid Pin 13 LED interference

// Push Buttons for each slot (Checkout buttons)
int buttons[] = {A0, A1, A2, A3}; 
int greenLEDs[] = {5, 7, 9, 11};
int redLEDs[] = {6, 8, 10, 12};

Servo gateServo;
unsigned long gateTimer = 0;
bool gateIsOpen = false;
bool carWaitingAtEntrance = false;
c:\Users\hp\OneDrive\Documents\Arduino\final_working_ver1
void setup() {
  Serial.begin(9600);
  gateServo.attach(servoPin);
  gateServo.write(0); // Ensure gate starts closed
  
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  
  for(int i = 0; i < 4; i++) {
    pinMode(buttons[i], INPUT_PULLUP);
    pinMode(greenLEDs[i], OUTPUT);
    pinMode(redLEDs[i], OUTPUT);
    digitalWrite(greenLEDs[i], HIGH); // All slots start Green
    digitalWrite(redLEDs[i], LOW);
  }
}

void loop() {
  // 1. Entrance Sensor Detection
  digitalWrite(trigPin, LOW); delayMicroseconds(2);
  digitalWrite(trigPin, HIGH); delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  long duration = pulseIn(echoPin, HIGH, 30000); 
  int distance = (duration > 0) ? (duration * 0.034 / 2) : 999;

  if (distance > 0 && distance < 20) {
    if (!carWaitingAtEntrance) Serial.println("CAR_READY");
    carWaitingAtEntrance = true;
  } else if (distance > 30) {
    carWaitingAtEntrance = false;
  }

  // 2. Physical Buttons (Checkout Signal)
  for (int i = 0; i < 4; i++) {
    if (digitalRead(buttons[i]) == LOW) {
      Serial.print("CHECKOUT:");
      Serial.println(i + 1);
      delay(1000); // Debounce to prevent multiple receipts
    }
  }

  // 3. Command Listener (From VB.NET)
  if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n');
    command.trim();

    if (command.startsWith("OCCUPY:")) {
      int slotNum = command.substring(7).toInt() - 1;
      digitalWrite(greenLEDs[slotNum], LOW);
      digitalWrite(redLEDs[slotNum], HIGH);
      openGate(); 
    }
    else if (command == "OPEN_GATE") {
      openGate(); // Opens for exit car after receipt is shown
    }
    else if (command.startsWith("VACATE:")) {
       int slotNum = command.substring(7).toInt() - 1;
       digitalWrite(greenLEDs[slotNum], HIGH);
       digitalWrite(redLEDs[slotNum], LOW);
    }
  }

  // Auto-close gate after 7 seconds
  if (gateIsOpen && (millis() - gateTimer > 3000)) {
    gateServo.write(0);   
    gateIsOpen = false;
    Serial.println("GATE:CLOSED");
  }
}

void openGate() {
  gateServo.write(90);
  gateIsOpen = true;
  gateTimer = millis();
  Serial.println("GATE:OPEN");
}