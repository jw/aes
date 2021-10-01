from pathlib import Path

from cryptography.fernet import Fernet

MESSAGE = """
Freude, schöner Götterfunken,
Tochter aus Elysium,
Wir betreten feuertrunken,
Himmlische, dein Heiligtum!"
"""


def recreate_file(path: Path, data: bytes, prefix: str = "> "):
    print(f"[{path}] {prefix}: {data}")
    path.write_bytes(data)


if __name__ == '__main__':
    root = Path("/home/jw/projects/aes")
    data = root / "data"
    data.mkdir(exist_ok=True)

    key = Fernet.generate_key()
    recreate_file(data / "key", key, "key")

    f = Fernet(key)
    token = f.encrypt(MESSAGE.encode())
    recreate_file(data / "encrypted", token, "encrypted")

    message = f.decrypt(token)
    recreate_file(data / "decrypted", message, "decrypted")

    assert message.decode() == MESSAGE
    print("Valid encryption/decryption.")
