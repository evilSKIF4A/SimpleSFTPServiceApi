using Microsoft.AspNetCore.Http.HttpResults;
using Renci.SshNet;
using ConnectionInfo = Renci.SshNet.ConnectionInfo;

namespace SimpleSFTPServiceApi.Services;

public class SftpService
{
    private readonly ConnectionInfo _connectionInfo = new PasswordConnectionInfo(
        DefaultSettings.Host, 
        DefaultSettings.Port,
        DefaultSettings.Login, 
        DefaultSettings.Password);
    
    public async Task<bool> IsConnected()
    {

        using var sftp = new SftpClient(_connectionInfo);
        try
        {
            await sftp.ConnectAsync(default);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
        finally
        {
            if (sftp.IsConnected)
                sftp.Disconnect();
        }
        return true;
    }
}