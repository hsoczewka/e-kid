# e-Kid
## SaaS Application for Managing Psychological-Pedagogical Counseling Centers

e-Kid is a multi-tenancy SaaS application designed to efficiently manage Psychological-Pedagogical Counseling Centers. The application provides robust functionality for permissions and roles, ensuring flexible and secure access management for different user groups. By leveraging the CQRS (Command Query Responsibility Segregation) pattern, e-Kid ensures efficient validation of incoming commands and requests, allowing a dedicated layer to verify user permissions and roles for executing specific actions.

## Purpose

This repository is intended as a training project where interesting patterns and a fascinating domain are modeled. The goal is to implement best practices in software design and architecture while providing a useful tool for managing psychological-pedagogical counseling centers.


## Features

- [x] **Permissions and Roles Management**: Granular control over user actions with flexible permissions and roles setup.
- [ ] **Therapist Availability**: Check the availability of therapists in real-time.
- [ ] **Therapy Room Availability**: Monitor the availability of therapy rooms.
- [ ] **Therapist Scheduling**: Therapists can mark their available days and hours.
- [ ] **Electronic Session Log**: Maintain an electronic log of therapy sessions.
- [ ] **Notifications**: Alerts for the director about sessions that did not occur or were not paid for.


## Technology Stack

- **Framework**: .NET 8
- **Language**: C#
- **Database**: PostgreSQL

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/hsoczewka/e-kid.git
    ```
2. Navigate to the project directory:
    ```bash
    cd e-kid
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Build the project:
    ```bash
    dotnet build
    ```
5. To run the application using Docker and `docker-compose`:
   1. Ensure Docker is installed and running on your system.
   2. In the project directory, build the Docker images and start the containers:
       ```bash
       docker-compose up --build
       ```
       ```bash
       dotnet run
       ```

## Usage

### Permissions and Roles

e-Kid allows administrators to define custom roles and permissions, ensuring that each user has access only to the features they need.

### Checking Availability

- **Therapists**: Users can check therapist availability through a user-friendly interface, ensuring optimal scheduling.
- **Therapy Rooms**: The application provides real-time updates on the availability of therapy rooms.

### Scheduling

Therapists can mark their available times, making it easy for clients and administrators to book sessions.

### Electronic Session Log

Maintain a digital log of all therapy sessions, accessible to authorized users for review and reporting.

### Notifications

Directors receive notifications about sessions that were missed or not paid for, enabling prompt follow-up actions.

## Contributing

We welcome contributions to enhance e-Kid. To contribute:

1. Fork the repository.
2. Create a new branch:
    ```bash
    git checkout -b feature-branch
    ```
3. Make your changes.
4. Commit your changes:
    ```bash
    git commit -m "your commit message"
    ```
5. Push to the branch:
    ```bash
    git push origin feature-branch
    ```
6. Open a pull request on GitHub.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or support, please contact [hubert.soczewka@gmail.com](mailto:hubert.soczewka@gmail.com).

---

Thank you for using e-Kid!