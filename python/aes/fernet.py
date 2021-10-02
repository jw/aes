from pathlib import Path
import sys

from cryptography.fernet import Fernet

MESSAGE = """
Freude, schöner Götterfunken,
Tochter aus Elysium,
Wir betreten feuertrunken,
Himmlische, dein Heiligtum!
"""


def recreate_file(path: Path, data: bytes, prefix: str = "> "):
    print(f"[{path}] {prefix}: {data}")
    path.write_bytes(data)


def fail(message, exit=-1):
    print(message)
    exit(exit)


def get_root():
    try:
        root = sys.argv[1]
    except IndexError:
        fail("Specify the root of the project as first parameter.")
    root = Path(root).resolve()
    if root.exists() and root.is_dir():
        print(f"Using {root} as root.")
    else:
        fail(f"Invalid project root specified: {root}.")
    return root


if __name__ == '__main__':

    # le mise-en-place
    root = get_root()
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
    print(f"Created a validly encrypted message in {data}.")
