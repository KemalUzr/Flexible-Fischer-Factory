# FlexibleFischerFactory
![alt text](https://github.com/KemalUzr/FlexibleFischerFactory/blob/master/.github/group.jpg)
- [Monitor App](#monitor-app)
  - [Setup development environment](#setup-development-environment)
  - [Linting](#linting)
  - [Testing](#testing)
  - [Deployment](#deployment)
- [Unity](#unity)
  - [TODO](#todo)
- [Guidelines](#guidelines)
  - [Code](#code)
  - [Git](#git)
    - [Example for a commit message](#example-for-a-commit-message)
    - [A properly formed git commit subject line should always be able to complete the following sentence](#a-properly-formed-git-commit-subject-line-should-always-be-able-to-complete-the-following-sentence)
    - [Rules for a great git commit message style](#rules-for-a-great-git-commit-message-style)
    - [Information in commit messages](#information-in-commit-messages)
    - [References in commit messages](#references-in-commit-messages)

## Monitor App

### Setup development environment

The monitor app packages can be installed with the following command:

```bash
pnpm install --frozen-lockfile --prefer-offline --no-optional --ignore-scripts
```

If you don't have `pnpm` installed, you can install it with the following command when node version 16 or later is installed (if you don't have node installed you can install it [here](https://nodejs.org/en/) and check your priviliges on either PS or CMD (windows)):

```bash
corepack enable && corepack prepare pnpm@latest --activate
```

It is recommended that you use the latest LTS version of `node`.

### Linting

To check if the code is following the code style guide you can use the following command:

```bash
pnpm run lint
```

This command will also run on PRs and will fail if the code is not following the code style guide. Therefor a PR can only be merged if the code is following the code style guide.
To automatically fix the code style guide you can use the following command:

```bash
pnpm run lint:fix
```

### Testing

To run the tests you can use the following command:

```bash
pnpm run test
```

This command will also run on PRs and will fail if the tests are failing. Therefor a PR can only be merged if the tests are passing.
If during development you want more information about the tests you can use the following command:

```bash
pnpm run test:verbose
```

### Deployment

To make sure the latest version of the application is running on the pi you first need to make sure that the code has a tagged version. This can be done by tagging the main branch with a version number on GitHub. This will trigger a GitHub action that will build the code and push it to the docker registry. The next step is to update the code on the pi.

This will update the code on the pi, the next step is to ssh into the pi and restart the docker container with the app running in it.

```bash
ssh pi@<ip-address>
```

```bash
docker pull flexiblefischerfactory/monitor-app:latest
```

If you changed the docker-compose file in this repo, please update the docker-compose file on the pi accordingly.
Last step is to restart the docker container with the following command when in the folder of the docker-compose file:

```bash
docker compose down && docker compose up -d
```

This will restart the docker container with the latest code.

If you want to inspect the logs of the docker container you can use the following command:

```bash
docker compose logs -f
```

## Unity

The Unity project is located in the `unity` folder. The project can be opened with Unity version 2021.3.20f1.
It has not been tested with other versions of Unity.

If you want a global view of the structure of the code you can open the design in the `designs` folder with [umlet](https://www.umlet.com/).

This code at the moment is a restructured version of the code that the previous group has made. Therefor the code is not `tested` with unit tests. The code is tested by running the app on the pi and checking if the app is working as expected. This is not ideal and should be improved in the future.

### TODO

The next steps to do are the following not in this specific order:

- [ ] Add unit tests
- [ ] Add integration tests
- [ ] Add all other elements of the FlexibleFischerFactory
- [ ] Link the Unity project to the data storage
- [ ] Make a simulation mode for the factory
- [ ] Make a live mode for the factory
- [ ] Make a replay mode for the factory

## Guidelines

### Code

This project follows the [code style guide](https://google.github.io/styleguide/csharp-style.html) of Google for `C#`.
For any other languages the Google style guides should also be used and can be found at [Google Style Guides](https://google.github.io/styleguide/).

### Git

```txt
Short (72 chars or less) summary

Refer to the issue #<IssueId>

All things below are optional.

More detailed explanatory text. Wrap it to 72 characters. The blank
line separating the summary from the body is critical (unless you omit
the body entirely).

Write your commit message in the imperative: "Fix bug" and not "Fixed
bug" or "Fixes bug." This convention matches up with commit messages
generated by commands like git merge and git revert.

Further paragraphs come after blank lines.

- Bullet points are okay, too.
- Typically a hyphen or asterisk is used for the bullet, followed by a
  single space. Use a hanging indent.
```

#### Example for a commit message

```txt
Add CPU arch filter scheduler support

In a mixed environment of…
```

#### A properly formed git commit subject line should always be able to complete the following sentence

If applied, this commit will *\<your subject line here\>*

#### Rules for a great git commit message style

- Separate subject from body with a blank line
- Do not end the subject line with a period
- Capitalize the subject line and each paragraph
- Use the imperative mood in the subject line
- Wrap lines at 72 characters
- Use the body to explain what and why you have done something. In most cases, you can leave out details about how a change has been made.

#### Information in commit messages

- Describe why a change is being made.
- How does it address the issue?
- What effects does the patch have?
- Do not assume the reviewer understands what the original problem was.
- Do not assume the code is self-evident/self-documenting.
- Read the commit message to see if it hints at improved code structure.
- The first commit line is the most important.
- Describe any limitations of the current code.
- Do not include patch set-specific comments.

Details for each point and good commit message examples can be found on [openstack](https://wiki.openstack.org/wiki/GitCommitMessages#Information_in_commit_messages).

#### References in commit messages

If the commit refers to an issue, add this information to the commit message header or body. e.g. the GitHub web platform automatically converts issue ids (e.g. #123) to links referring to the related issue.

In header:

```txt
[#123] Refer to GitHub issue…
```

```txt
CAT-123 Refer to Jira ticket with project identifier CAT…
```

In body:

```txt
…
Fixes #123, #124
```
