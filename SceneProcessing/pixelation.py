import sys
print(sys.executable)

from PIL import Image, ImageFilter

# Load the image
image_path = "Pixelation/image.png"
image = Image.open(image_path)

# Pixelate the image by resizing it to a smaller size and then back to the original size
small_image = image.resize((image.width // 10, image.height // 10), Image.NEAREST)
pixelated_image = small_image.resize((image.width, image.height), Image.NEAREST)

# Save the pixelated image
pixelated_image_path = "Pixelation/pixelated_image.png"
pixelated_image.save(pixelated_image_path)
