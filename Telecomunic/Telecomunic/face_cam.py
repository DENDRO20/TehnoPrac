import cv2
import telebot
import time
import os
import threading
import sys

TOKEN = '7728228304:AAH3wSaS5bOGD4MfJqw4jx_OY7dgP-vj-4o'
CHAT_ID = '1059140821'

bot = telebot.TeleBot(TOKEN)
response_received = threading.Event()

cam = cv2.VideoCapture(0)
ret, frame = cam.read()
if ret:
    cv2.imwrite("face.jpg", frame)
cam.release()

with open("face.jpg", "rb") as photo:
    bot.send_photo(CHAT_ID, photo, caption="Is this you? Yes / No")

@bot.message_handler(func=lambda msg: msg.chat.id == int(CHAT_ID) and msg.text.lower() in ["yes", "no"])
def handle_response(msg):
    verdict = "YES" if msg.text.lower() == "yes" else "NO"

    with open("verdict.txt", "w") as f:
        f.write(verdict)

    bot.send_message(CHAT_ID, f"Am salvat răspunsul tău: {verdict}. Oprește scriptul.")

    response_received.set()
    bot.stop_polling()
    sys.exit(0)

threading.Thread(target=bot.polling, kwargs={"none_stop": True}).start()

print("Aștept răspunsul de la administrator...")
if not response_received.wait(timeout=120):
    with open("verdict.txt", "w") as f:
        f.write("NO_RESPONSE")
    print("Timpul a expirat. Fără răspuns.")
    bot.send_message(CHAT_ID, "Timpul de răspuns a expirat. Acces blocat.")
    bot.stop_polling()
    sys.exit(0)
