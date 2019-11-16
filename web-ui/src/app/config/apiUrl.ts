
export const apiUrl = {
    // "api": "http://citybase"
    "baseUrl":"/api",


    "getCountry": "/countries",
    "getStates": "/countries/"+localStorage.getItem("countryId")
}
