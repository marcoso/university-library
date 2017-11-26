@echo off

setlocal

mongo UniversityLibrary --eval "db.dropDatabase()"
mongoimport -d UniversityLibrary -c User User.json
mongoimport -d UniversityLibrary -c Book Book.json

:end
