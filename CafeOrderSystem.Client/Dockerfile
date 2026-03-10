# syntax=docker/dockerfile:1

FROM node:20-alpine AS build
WORKDIR /app

COPY CafeOrderSystem.Client/package.json CafeOrderSystem.Client/package-lock.json ./
RUN npm ci

COPY CafeOrderSystem.Client/ ./

# If you want to bake API URL at build-time, pass: --build-arg VITE_API_BASE_URL=/api
ARG VITE_API_BASE_URL
ENV VITE_API_BASE_URL=${VITE_API_BASE_URL}

ARG VITE_STRIPE_PUBLISHABLE_KEY
ENV VITE_STRIPE_PUBLISHABLE_KEY=${VITE_STRIPE_PUBLISHABLE_KEY}

RUN npm run build

FROM nginx:1.27-alpine AS final
COPY CafeOrderSystem.Client/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist/ /usr/share/nginx/html/

EXPOSE 80
