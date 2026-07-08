# Build Your Own Git

A Git implementation built from scratch in **C#** using the **.NET** platform to understand Git's internal architecture, object storage, version control mechanisms, and repository management.

---

## About

This project is part of my **Build Your Own** series, where I recreate core software systems from scratch to gain a deeper understanding of how they work internally.

Rather than using Git as a developer, this project focuses on implementing Git's core components, including:

- Repository initialization
- Git object database
- Blob, tree, and commit objects
- References (HEAD and branches)
- Staging area (index)
- Commit history
- Checkout
- Branching
- Merge (Fast Forward)
- Diff

The goal is to understand the design decisions that make Git a fast, distributed version control system.

---

## Project Goals

- Learn Git internals by implementing them from scratch
- Understand Git's content-addressable object database
- Explore how commits, trees, and blobs are stored
- Learn repository and reference management
- Build a functional command-line Git implementation without using Git libraries

---

## Features

### Planned

- [ ] CLI command parser
- [ ] Repository initialization (`init`)
- [ ] Object database
- [ ] Blob objects
- [ ] Tree objects
- [ ] Commit objects
- [ ] HEAD and references
- [ ] Commit history (`log`)
- [ ] Checkout
- [ ] Staging area (`index`)
- [ ] Repository status
- [ ] Commit workflow
- [ ] Branches
- [ ] Fast-forward merge
- [ ] Simple diff
- [ ] Garbage collection (optional)

---

## Project Structure

```
build-your-own-git/

├── Git/
│   ├── Commands/
│   ├── Repository/
│   ├── Utils/
│   └── Program.cs
│
├── docs/
│
├── BuildYourOwnGit.slnx
├── README.md
├── LICENSE
└── .gitignore
```

> Additional folders will be introduced as the project evolves.

---

## Tech Stack

- C#
- .NET
- SHA-1 Cryptography
- Deflate Compression
- File System APIs

---

## Milestones

| Milestone | Description | Status |
|-----------|-------------|--------|
| 0 | CLI Skeleton | ⏳ |
| 1 | Repository Initialization | ⏳ |
| 2 | Git Object Database | ⏳ |
| 3 | Blob Objects | ⏳ |
| 4 | Tree Objects | ⏳ |
| 5 | Reading Trees | ⏳ |
| 6 | Commit Objects | ⏳ |
| 7 | References & HEAD | ⏳ |
| 8 | Commit History | ⏳ |
| 9 | Checkout | ⏳ |
| 10 | Staging Area | ⏳ |
| 11 | Status | ⏳ |
| 12 | Commit Workflow | ⏳ |
| 13 | Branches | ⏳ |
| 14 | Fast-Forward Merge | ⏳ |
| 15 | Diff | ⏳ |
| 16 | Garbage Collection (Optional) | ⏳ |

---

## Documentation

Detailed documentation for each major milestone will be available in the `docs/` directory as the project progresses.

---

## Learning Outcomes

By the end of this project, I aim to understand:

- Content-addressable storage
- Git object model
- Blob, tree, and commit relationships
- Directed Acyclic Graph (DAG)
- Repository references
- Branching mechanisms
- Three-tree architecture
- Version control internals

---

## Build

Clone the repository:

```bash
git clone https://github.com/arushig2/build-your-own-git.git
```

Navigate to the project:

```bash
cd build-your-own-git
```

Run the project:

```bash
dotnet run --project Git
```

---

## Build Your Own Series

This repository is part of my **Build Your Own** series, where I recreate widely used software systems from scratch to better understand their internal implementation.

Current projects:

- ✅ Build Your Own HTTP Server
- 🚧 Build Your Own Git

---

## License

This project is licensed under the MIT License.