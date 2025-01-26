FROM --platform=linux/arm64 node:16 AS build
WORKDIR /app
COPY package*.json ./
RUN npm ci --unsafe-perm --prefer-offline --no-audit
COPY . ./
RUN npm run build

FROM --platform=linux/arm64 nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]