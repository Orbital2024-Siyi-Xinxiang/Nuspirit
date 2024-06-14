import cv2
import numpy as np
import pytesseract

image_base_path = "./../Utilities/MapsNUS/SOC/"
image_path = image_base_path + "COM1_01.jpg"

def preprocess_image(image_path):
    image = cv2.imread(image_path)
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    _, binary = cv2.threshold(gray, 200, 255, cv2.THRESH_BINARY_INV)
    return binary, image

def detect_contours(binary_image):
    contours, _ = cv2.findContours(binary_image, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    return contours

def draw_contours(image, contours):
    for contour in contours:
        if cv2.contourArea(contour) > 100:  # Filter small contours
            x, y, w, h = cv2.boundingRect(contour)
            cv2.rectangle(image, (x, y), (x+w, y+h), (0, 255, 0), 2)
    return image

def extract_text(image):
    config = '--psm 6'  # Set the page segmentation mode to 6 (Assume a single uniform block of text)
    text = pytesseract.image_to_string(image, config=config)
    return text

def identify_areas(image, contours):
    areas = {}
    for contour in contours:
        x, y, w, h = cv2.boundingRect(contour)
        roi = image[y:y+h, x:x+w]
        text = extract_text(roi)
        areas[text.strip()] = (x, y, w, h)
    return areas

def main():
    # Load and preprocess the image
    binary_image, original_image = preprocess_image(image_path)

    # Detect contours
    contours = detect_contours(binary_image)

    # Draw contours on the original image
    contoured_image = draw_contours(original_image.copy(), contours)

    # Identify areas using OCR
    areas = identify_areas(original_image, contours)

    # Print identified areas
    for area, coordinates in areas.items():
        print(f"{area}: {coordinates}")

    # Display the image with contours
    cv2.imshow('Contoured Image', contoured_image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

if __name__ == "__main__":
    main()
