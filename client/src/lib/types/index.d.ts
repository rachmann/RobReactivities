// any *.d.ts file is a typescript declaration file
// this file is used to declare types for the client side

type Activity = {  // could be a type or interface
    id: string
    title: string
    date: string
    description: string
    category: string
    isCancelled: boolean
    city: string
    venue: string
    latitude: number
    longitude: number
}
