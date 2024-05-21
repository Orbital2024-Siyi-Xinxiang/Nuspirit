//
//  AuthService.swift
//  Orbital
//
//  Created by Wulala's Macbook on 12/5/24.
//

import Foundation

class AuthService {
    static let shared = AuthService()
    let baseUrl = "http://localhost:3000/api"
    
    func register(username: String, password: String, email: String, completion: @escaping (Bool, String) -> Void) {
        guard let url = URL(string: "\(baseUrl)/auth/register") else {
            completion(false, "Invalid URL")
            return
        }

        let body: [String: Any] = [
            "username": username,
            "password": password,
            "email": email  // Include email in the body
        ]

        var request = URLRequest(url: url)
        request.httpMethod = "POST"
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.httpBody = try? JSONSerialization.data(withJSONObject: body)

        URLSession.shared.dataTask(with: request) { data, response, error in
            if let error = error {
                DispatchQueue.main.async {
                    completion(false, "Registration failed: \(error.localizedDescription)")
                }
                
                return
            }
            
            guard let data = data else {
                DispatchQueue.main.async {
                    completion(false, "No data received")
                }
                return
            }
            
            if let httpResponse = response as? HTTPURLResponse, httpResponse.statusCode != 201 {
                let message = String(data: data, encoding: .utf8) ?? "Unknown error"
                DispatchQueue.main.async {
                    completion(false, "Registration failed: \(message)")
                }
            } else {
                DispatchQueue.main.async {
                    completion(true, "User registered successfully")
                }
            }
        }.resume()
    }

    
    
    func login(username: String, password: String, completion: @escaping (Bool, String) -> Void) {
        guard let url = URL(string: "\(baseUrl)/auth/login") else {
            completion(false, "Invalid URL")
            return
        }

        let body: [String: Any] = [
            "username": username,
            "password": password
        ]

        var request = URLRequest(url: url)
        request.httpMethod = "POST"
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.httpBody = try? JSONSerialization.data(withJSONObject: body)

        URLSession.shared.dataTask(with: request) { data, response, error in
            if let error = error {
                DispatchQueue.main.async {
                    completion(false, "Login failed: \(error.localizedDescription)")
                }
                return
            }
            
            guard let data = data, let httpResponse = response as? HTTPURLResponse else {
                DispatchQueue.main.async {
                    completion(false, "No data received or invalid response")
                }
                return
            }
            
            if httpResponse.statusCode == 200 {
                DispatchQueue.main.async {
                    completion(true, "Logged in successfully")
                }
            } else {
                let message = String(data: data, encoding: .utf8) ?? "Unknown error"
                DispatchQueue.main.async {
                    completion(false, "Login failed: \(message)")
                }
            }
        }.resume()
    }

    
    func deleteAccount(username: String, completion: @escaping (Bool, String) -> Void) {
        guard let url = URL(string: "\(baseUrl)/auth/delete") else {
            completion(false, "Invalid URL")
            return
        }

        let body: [String: Any] = ["username": username]

        var request = URLRequest(url: url)
        request.httpMethod = "DELETE"
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.httpBody = try? JSONSerialization.data(withJSONObject: body)

        URLSession.shared.dataTask(with: request) { data, response, error in
            if let error = error {
                DispatchQueue.main.async {
                    completion(false, "Account deletion failed: \(error.localizedDescription)")
                }
                return
            }

            guard let httpResponse = response as? HTTPURLResponse, httpResponse.statusCode == 200 else {
                DispatchQueue.main.async {
                    completion(false, "Failed to delete account")
                }
                return
            }

            DispatchQueue.main.async {
                completion(true, "Account successfully deleted")
            }
        }.resume()
    }

}
