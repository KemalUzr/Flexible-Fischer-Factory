FROM node:18-alpine AS builder

# Set the workdir for compacter commands
WORKDIR /app

# Copy the package.json and pnpm-lock.yaml files
COPY package.json pnpm-lock.yaml ./

# Install pnpm
RUN corepack enable && \
	corepack prepare pnpm@latest --activate

# Configure pnpm
RUN pnpm config set store-dir /app/.pnpm-store

# Install dependencies
RUN pnpm install --frozen-lockfile --prefer-offline --no-optional --ignore-scripts

# Copy the rest of the files
COPY . .

# Build the app
RUN pnpm run build


# Stage 2: Serve the app
FROM node:18-alpine AS runner

# Set ARGs for the app to initialize ENVs
ARG NODE_ENV=production
ARG MQTT_BROKER_HOST=192.168.0.10
ARG MQTT_BROKER_PORT=1883

# Set ENVs
ENV NODE_ENV=${NODE_ENV}
ENV MQTT_BROKER_HOST=${MQTT_BROKER_HOST}
ENV MQTT_BROKER_PORT=${MQTT_BROKER_PORT}

# Set the workdir for compacter commands
WORKDIR /app

# Copy the package.json and pnpm-lock.yaml files
COPY package.json pnpm-lock.yaml ./

# Install pnpm
RUN corepack enable && \
	corepack prepare pnpm@latest --activate

# Configure pnpm
RUN pnpm config set store-dir /app/.pnpm-store

# Copy the pnpm store from the builder
# This is done to avoid the need to download the dependencies again
COPY --from=builder /app/.pnpm-store ./.pnpm-store

# Install dependencies
# This will use the pnpm store copied from the builder to link only the production dependencies
RUN pnpm install --frozen-lockfile --prefer-offline --no-optional --ignore-scripts --production

# Create data folder
RUN mkdir database

# Copy the built app from the builder
COPY --from=builder /app/dist ./

# Start the app
CMD ["node", "index.js"]
