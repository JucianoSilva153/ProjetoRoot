#!/usr/bin/env bash
# wait-for-it.sh

set -e

host="$1"
shift
cmd="$@"

until nc -z $host; do
  >&2 echo "O serviço $host ainda não está pronto, aguardando..."
  sleep 2
done

>&2 echo "O serviço $host está pronto, iniciando o comando."
exec $cmd
