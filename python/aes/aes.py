from cryptography.fernet import Fernet

MESSAGE = """
Freude, schöner Götterfunken,
Tochter aus Elysium,
Wir betreten feuertrunken,
Himmlische, dein Heiligtum!"
"""

if __name__ == '__main__':
    key = Fernet.generate_key()
    print(f"Key: {key}")
    f = Fernet(key)
    token = f.encrypt(MESSAGE.encode())
    print(f"Encrypted: {token}")
    message = f.decrypt(token).decode()
    print(f"Decrypted: {message}")
    assert message == MESSAGE

