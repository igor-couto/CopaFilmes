FROM --platform=linux/arm64 node:16 AS build
WORKDIR /app
COPY frontend/package*.json ./
RUN npm ci --unsafe-perm --prefer-offline --no-audit
COPY frontend/ ./
RUN npm run build