FROM mcr.microsoft.com/dotnet/sdk:7.0
# Avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive

ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

# Configure apt and install packages
RUN apt-get update \
  && apt-get -y install --no-install-recommends apt-utils dialog libicu67 libssl1.1 2>&1 \
  #
  # Verify wget, jq, unzip, git and process tools installed
  && apt-get -y install git iproute2 procps wget unzip jq \
  #
  # Install Docker CE CLI
  && apt-get install -y apt-transport-https ca-certificates curl gnupg-agent software-properties-common lsb-release \
  && curl -fsSL https://download.docker.com/linux/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/gpg | (OUT=$(apt-key add - 2>&1) || echo $OUT) \
  && add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/$(lsb_release -is | tr '[:upper:]' '[:lower:]') $(lsb_release -cs) stable" \
  && apt-get update \
  && apt-get install -y docker-ce-cli \
  #
  # Install Docker Compose
  && curl -sSL "https://github.com/docker/compose/releases/download/1.24.0/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose \
  && chmod +x /usr/local/bin/docker-compose \
  #
  # Install Node
  && curl -sL https://deb.nodesource.com/setup_18.x | bash - \
  && apt-get install -y nodejs \
  #
  # Install Midnight Commander
  && apt-get install -y mc \
  #
  # Install global packages
  && npm install npm-check-updates -g \
  #
  # Install Azure CLI
  && curl -sL https://aka.ms/InstallAzureCLIDeb | bash \
  #
  # Install Dotnet-ef
  && dotnet tool install --global dotnet-ef \
  #
  # Install kubectl
  && curl -sL https://packages.cloud.google.com/apt/doc/apt-key.gpg | apt-key add - \
  && echo "deb https://apt.kubernetes.io/ kubernetes-xenial main" | tee -a /etc/apt/sources.list.d/kubernetes.list \
  && apt-get update \
  && apt-get install -y kubectl \
  #
  # Create a non-root user to use if preferred - see https://aka.ms/vscode-remote/containers/non-root-user.
  && groupadd --gid $USER_GID $USERNAME \
  && useradd -s /bin/bash --uid $USER_UID --gid $USER_GID -m $USERNAME \
  #
  # [Optional] Add sudo support for the non-root user
  && apt-get install -y sudo \
  && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME\
  && chmod 0440 /etc/sudoers.d/$USERNAME \
  #
  # Clean up
  && apt-get autoremove -y \
  && apt-get clean -y \
  && rm -rf /var/lib/apt/lists/*

# Switch back to dialog for any ad-hoc use of apt-get
ENV DEBIAN_FRONTEND=

CMD ["bash"]
