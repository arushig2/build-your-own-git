# Git Object Database and Blob Objects

## Overview

Git stores every piece of data as an object inside the `.git/objects` directory. Whether it's a file, directory, or commit, everything is represented using Git's object model.

This milestone implements the foundation of Git's storage system by supporting:

- Creating blob objects (`hash-object`)
- Reading blob objects (`cat-file -p`)

---

## Learning Goals

- Understand Git's object database
- Learn how blob objects are created
- Understand SHA-1 object identification
- Learn how Git compresses object data
- Read and parse Git objects

---

# How Git Stores a File

Consider a file named `hello.txt`.

```
hello world
```

Git does not store the raw file directly.

Instead it creates an internal representation:

```
blob 12\0hello world
```

where

- `blob` → object type
- `12` → size of the file in bytes
- `\0` → null byte separator
- `hello world` → actual file contents

The SHA-1 hash is computed over this complete representation, not just the file contents.

---

# Object Storage Flow

```
File
    │
    ▼
Create Blob Header
    │
    ▼
blob <size>\0content
    │
    ▼
Compute SHA-1
    │
    ▼
Compress using Deflate
    │
    ▼
Store inside

.git/objects/xx/yyyyyyyy...
```

Example:

```
95d09f2b10159347eece71399a7e2e907ea3df4f

↓

.git/objects/95/d09f2b10159347eece71399a7e2e907ea3df4f
```

The first two hexadecimal characters become the directory name, while the remaining characters become the filename.

This layout prevents thousands of files from existing in a single directory.

---

# Reading Objects

The `cat-file -p` command performs the reverse operation.

```
Object Hash
     │
     ▼
Locate Object
     │
     ▼
Read Compressed Bytes
     │
     ▼
Decompress
     │
     ▼
blob <size>\0content
     │
     ▼
Separate Header and Content
     │
     ▼
Display File Contents
```

The implementation locates the null-byte separator (`\0`) to distinguish the header from the actual blob contents.

---

# Commands Implemented

Create a blob object:

```bash
mygit hash-object hello.txt
```

Read a blob object:

```bash
mygit cat-file -p <object_hash>
```

---

# Verification

The implementation was verified against Git by comparing:

- Object hash generation
- Object storage layout
- Blob contents returned by `cat-file -p`

This ensures the implementation follows Git's loose object format.

---

# Key Takeaways

- Git stores content as objects rather than files.
- Every object is uniquely identified using SHA-1.
- Objects are compressed before being written to disk.
- Blob objects represent file contents only.
- `cat-file -p` reconstructs the original file by decompressing and parsing the stored object.