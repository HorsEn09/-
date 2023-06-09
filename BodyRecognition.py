import cv2
from cvzone.PoseModule import PoseDetector
import socket

ip_address = 'http://192.168.31.43:4747/video'

# camera = cv2.VideoCapture(ip_address)

camera = cv2.VideoCapture(0)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

detector = PoseDetector()
posList = []

while True:
    success, img = camera.read()
    img = detector.findPose(img)
    lmList, bboxInfo = detector.findPosition(img)

    if bboxInfo:
        lmString = ''
        for lm in lmList:
            lmString += f'{lm[1]},{img.shape[0]-lm[2]},{lm[3]},'
        posList.append(lmString)

        data = lmString
        sock.sendto(str.encode(str(data)), serverAddressPort)

    cv2.imshow("Image", img)
    key = cv2.waitKey(1)
