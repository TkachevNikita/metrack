FROM node:18 as build
WORKDIR /src
COPY . .
RUN npm install && \
    npm run build
FROM nginx:stable
COPY --from=build /src/dist/metrack.client/browser /usr/share/nginx/html
